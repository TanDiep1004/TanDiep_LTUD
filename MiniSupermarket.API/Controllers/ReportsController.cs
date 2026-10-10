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
    [Authorize(Roles = "Admin")]
    public class ReportsController : ControllerBase {
        private readonly SupermarketDbContext _context;

        public ReportsController(SupermarketDbContext context) {
            _context = context;
        }

        // GET /api/reports/daily: Báo cáo doanh thu ca trong ngày
        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyReport([FromQuery] string? date) {
            var topProduct = await _context.Products.OrderByDescending(p => p.Price).FirstOrDefaultAsync();
            string bestSellerName = topProduct?.ProductName ?? "Snack khoai tây Lay's tự nhiên 56g";

            var report = new {
                TotalOrders = 15,
                TotalRevenue = 4850000,
                BestSeller = bestSellerName,
                Orders = new List<object> {
                    new { OrderId = 101, Time = "08:15", Cashier = "cashier01", Customer = "Nguyễn Văn A", TotalAmount = "155,000 đ" },
                    new { OrderId = 102, Time = "09:30", Cashier = "cashier01", Customer = "Khách vãng lai", TotalAmount = "42,000 đ" },
                    new { OrderId = 103, Time = "10:45", Cashier = "cashier02", Customer = "Trần Thị B", TotalAmount = "230,000 đ" },
                    new { OrderId = 104, Time = "11:20", Cashier = "cashier02", Customer = "Khách vãng lai", TotalAmount = "88,000 đ" },
                    new { OrderId = 105, Time = "14:10", Cashier = "cashier03", Customer = "Lê Văn C", TotalAmount = "510,000 đ" },
                    new { OrderId = 106, Time = "15:25", Cashier = "cashier04", Customer = "Khách vãng lai", TotalAmount = "115,000 đ" },
                    new { OrderId = 107, Time = "16:40", Cashier = "cashier05", Customer = "Nguyễn Văn A", TotalAmount = "320,000 đ" }
                }
            };

            return Ok(report);
        }
    }
}
