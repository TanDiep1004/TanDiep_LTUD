using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
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

        // POST /api/orders/checkout: Xử lý thanh toán đơn hàng tại quầy POS
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequestDto request) {
            if (request == null || request.Items == null || request.Items.Count == 0) {
                return BadRequest(new { message = "Giỏ hàng không có sản phẩm nào!" });
            }

            decimal totalAmount = 0;

            // 1. Cập nhật tồn kho cho từng sản phẩm
            foreach (var item in request.Items) {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null) {
                    product.StockQuantity = Math.Max(0, product.StockQuantity - item.Quantity);
                    totalAmount += item.Quantity * item.UnitPrice;
                }
            }

            // 2. Tích điểm cho khách hàng thân thiết nếu có số điện thoại
            if (!string.IsNullOrWhiteSpace(request.CustomerPhone)) {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == request.CustomerPhone.Trim());
                if (customer != null) {
                    int pointsEarned = (int)(totalAmount / 10000); // 10.000 đ = 1 điểm
                    customer.RewardPoints += pointsEarned;
                    if (customer.RewardPoints >= 200) customer.MembershipRank = "Bạch Kim";
                    else if (customer.RewardPoints >= 100) customer.MembershipRank = "Vàng";
                    else if (customer.RewardPoints >= 30) customer.MembershipRank = "Bạc";
                    else customer.MembershipRank = "Chuẩn";
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new {
                success = true,
                message = "Thanh toán thành công và đã trừ tồn kho!",
                orderId = new Random().Next(1000, 9999),
                totalAmount = totalAmount,
                cashier = request.CashierUsername,
                createdAt = DateTime.Now
            });
        }
    }

    public class CheckoutRequestDto {
        public string CashierUsername { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public List<CheckoutItemDto> Items { get; set; } = new();
    }

    public class CheckoutItemDto {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
