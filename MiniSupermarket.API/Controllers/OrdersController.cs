using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.DTOs;
using MiniSupermarket.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSupermarket.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Cashier")]
    public class OrdersController : ControllerBase {
        private readonly SupermarketDbContext _context;

        public OrdersController(SupermarketDbContext context) {
            _context = context;
        }

        // GET /api/orders: Lấy danh sách hóa đơn kèm chi tiết (Eager Loading Include / ThenInclude)
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var orders = await _context.Orders
                .AsNoTracking()
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderResponseDto {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    CashierUsername = o.CashierUsername,
                    CustomerId = o.CustomerId,
                    CustomerName = o.Customer != null ? o.Customer.CustomerName : "Khách vãng lai",
                    TotalAmount = o.TotalAmount,
                    PaymentMethod = o.PaymentMethod,
                    Items = o.OrderDetails.Select(od => new OrderDetailResponseDto {
                        OrderDetailId = od.OrderDetailId,
                        ProductId = od.ProductId,
                        ProductName = od.Product != null ? od.Product.ProductName : string.Empty,
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice
                    }).ToList()
                })
                .ToListAsync();

            return Ok(orders);
        }

        // POST /api/orders/checkout: Xử lý thanh toán POS kiểm soát toàn vẹn giao dịch chuẩn ACID (SqlTransaction)
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequestDto request) {
            if (request == null || request.Items == null || request.Items.Count == 0) {
                return BadRequest(new { message = "Giỏ hàng không có sản phẩm nào!" });
            }

            // Mở giao dịch chuẩn ACID (Atomicity, Consistency, Isolation, Durability)
            await using var dbTransaction = await _context.Database.BeginTransactionAsync();
            try {
                decimal totalAmount = 0;
                var sqlConn = (SqlConnection)_context.Database.GetDbConnection();
                var sqlTran = (SqlTransaction)dbTransaction.GetDbTransaction();

                // 1. Tiêu chí 32, 33, 35: Kiểm tra tồn kho & trừ kho an toàn bằng ADO.NET trong SqlTransaction
                // Tiêu chí 35: Khi kho hết hàng / không đủ hàng: Tự gọi transaction.Rollback(), không lưu hóa đơn rác vào CSDL
                foreach (var item in request.Items) {
                    // Kiểm tra số lượng tồn kho thực tế bằng ADO.NET SqlCommand + AddWithValue + SqlDataReader
                    const string checkStockSql = "SELECT ProductName, StockQuantity FROM Products WHERE ProductId = @ProductId";
                    await using var checkCmd = new SqlCommand(checkStockSql, sqlConn, sqlTran);
                    checkCmd.Parameters.AddWithValue("@ProductId", item.ProductId);

                    await using var reader = await checkCmd.ExecuteReaderAsync();
                    if (!await reader.ReadAsync()) {
                        await reader.CloseAsync();
                        await dbTransaction.RollbackAsync();
                        return NotFound(new { message = $"Không tìm thấy sản phẩm có ID = {item.ProductId}!" });
                    }

                    string prodName = reader.GetString(0);
                    int currentStock = reader.GetInt32(1);
                    await reader.CloseAsync();

                    // Tiêu chí 35: Kho hết hàng hoặc không đủ số lượng bán -> Rollback ngay lập tức
                    if (currentStock < item.Quantity) {
                        await dbTransaction.RollbackAsync();
                        return BadRequest(new { 
                            success = false,
                            message = $"Sản phẩm '{prodName}' trong kho không đủ hàng (Hiện còn: {currentStock}, yêu cầu mua: {item.Quantity})! Giao dịch đã tự động hoàn tác (Rollback), không lưu hóa đơn rác." 
                        });
                    }

                    // Trừ tồn kho bằng ADO.NET SqlCommand + AddWithValue chống SQL Injection
                    const string deductSql = @"
                        UPDATE Products 
                        SET StockQuantity = StockQuantity - @Qty 
                        WHERE ProductId = @ProductId";

                    await using var cmd = new SqlCommand(deductSql, sqlConn, sqlTran);
                    cmd.Parameters.AddWithValue("@Qty", item.Quantity);
                    cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                    await cmd.ExecuteNonQueryAsync();

                    totalAmount += item.Quantity * item.UnitPrice;
                }

                // 2. Tra cứu, đổi điểm thưởng trừ tiền và tích điểm cho khách hàng thân thiết nếu có số điện thoại (Tiêu chí 47)
                int? customerId = null;
                decimal discountAmount = 0;
                int pointsUsed = 0;

                if (!string.IsNullOrWhiteSpace(request.CustomerPhone)) {
                    var customer = await _context.Customers
                        .FirstOrDefaultAsync(c => c.PhoneNumber == request.CustomerPhone.Trim());
                    if (customer != null) {
                        customerId = customer.CustomerId;

                        // Tiêu chí 47: Đổi Điểm Thưởng Trừ Tiền Hóa Đơn (Loyalty Points Redemption)
                        // Kỹ thuật: Cập nhật đồng thời trừ điểm trong bảng Customers và trừ tiền thanh toán FinalAmount trong cùng một SqlTransaction
                        if (request.PointsToRedeem > 0) {
                            pointsUsed = Math.Min(request.PointsToRedeem, customer.RewardPoints);
                            discountAmount = pointsUsed * 1000m;
                            if (discountAmount > totalAmount) {
                                discountAmount = totalAmount;
                                pointsUsed = (int)(discountAmount / 1000m);
                            }

                            // 1. Trừ điểm thưởng trực tiếp trong bảng Customers qua ADO.NET SqlCommand bọc trong SqlTransaction
                            const string deductPointsSql = @"
                                UPDATE Customers 
                                SET RewardPoints = RewardPoints - @PointsUsed 
                                WHERE CustomerId = @CustomerId";
                            await using var deductCmd = new SqlCommand(deductPointsSql, sqlConn, sqlTran);
                            deductCmd.Parameters.AddWithValue("@PointsUsed", pointsUsed);
                            deductCmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                            await deductCmd.ExecuteNonQueryAsync();

                            customer.RewardPoints -= pointsUsed;
                        }

                        // 2. Tính số tiền thanh toán thực tế FinalAmount sau khi trừ tiền đổi điểm thưởng
                        decimal finalAmount = Math.Max(0, totalAmount - discountAmount);

                        // 3. Tích lũy điểm mới (10.000 đ = 1 điểm) qua ADO.NET SqlCommand bọc trong SqlTransaction
                        int pointsEarned = (int)(finalAmount / 10000);
                        if (pointsEarned > 0) {
                            const string earnPointsSql = @"
                                UPDATE Customers 
                                SET RewardPoints = RewardPoints + @PointsEarned 
                                WHERE CustomerId = @CustomerId";
                            await using var earnCmd = new SqlCommand(earnPointsSql, sqlConn, sqlTran);
                            earnCmd.Parameters.AddWithValue("@PointsEarned", pointsEarned);
                            earnCmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                            await earnCmd.ExecuteNonQueryAsync();

                            customer.RewardPoints += pointsEarned;
                        }

                        // 4. Cập nhật hạng thành viên trong SqlTransaction
                        string newRank = customer.RewardPoints >= 200 ? "Bạch Kim"
                                       : (customer.RewardPoints >= 100 ? "Vàng"
                                       : (customer.RewardPoints >= 30 ? "Bạc" : "Chuẩn"));
                        const string updateRankSql = "UPDATE Customers SET MembershipRank = @Rank WHERE CustomerId = @CustomerId";
                        await using var rankCmd = new SqlCommand(updateRankSql, sqlConn, sqlTran);
                        rankCmd.Parameters.AddWithValue("@Rank", newRank);
                        rankCmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        await rankCmd.ExecuteNonQueryAsync();

                        // Tránh EF Core tracking đối tượng Customer vì đã cập nhật trực tiếp qua SqlCommand trong transaction
                        _context.Entry(customer).State = EntityState.Unchanged;

                        totalAmount = finalAmount;
                    }
                }

                // 3. Lưu Hóa đơn (Order) và Chi tiết hóa đơn (OrderDetails) vào SQL Server
                var newOrder = new Order {
                    OrderDate = DateTime.Now,
                    CashierUsername = string.IsNullOrWhiteSpace(request.CashierUsername) ? "cashier01" : request.CashierUsername,
                    CustomerId = customerId,
                    TotalAmount = totalAmount,
                    PaymentMethod = "Tiền mặt",
                    OrderDetails = request.Items.Select(i => new OrderDetail {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice
                    }).ToList()
                };

                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                // 4. Xác nhận hoàn tất giao dịch (Commit Transaction)
                await dbTransaction.CommitAsync();

                return Ok(new {
                    success = true,
                    message = pointsUsed > 0 
                        ? $"Thanh toán thành công! Đã đổi {pointsUsed} điểm thưởng (trừ {discountAmount:N0} đ), lưu hóa đơn và trừ kho chuẩn ACID!" 
                        : "Thanh toán thành công, đã lưu hóa đơn và trừ tồn kho chuẩn ACID!",
                    orderId = newOrder.OrderId,
                    totalAmount = totalAmount,
                    discountAmount = discountAmount,
                    pointsUsed = pointsUsed,
                    cashier = newOrder.CashierUsername,
                    createdAt = newOrder.OrderDate
                });
            } catch (Exception ex) {
                await dbTransaction.RollbackAsync();
                return BadRequest(new { success = false, message = "Giao dịch thất bại, đã hoàn tác (Rollback): " + ex.Message });
            }
        }
    }

    public class CheckoutRequestDto {
        public string CashierUsername { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public int PointsToRedeem { get; set; } = 0; // Tiêu chí 47: Đổi điểm thưởng trừ tiền
        public List<CheckoutItemDto> Items { get; set; } = new();
    }

    public class CheckoutItemDto {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
