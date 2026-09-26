using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Bắt buộc phải có Token mới gọi được các API trong Controller này
    public class CategoriesController : ControllerBase
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Bánh kẹo & Đồ ăn vặt", Description = "Các loại snack, bánh quy, kẹo dẻo, sô-cô-la" },
            new Category { CategoryId = 2, CategoryName = "Nước giải khát & Trà", Description = "Nước ngọt, nước khoáng..." },
            new Category { CategoryId = 3, CategoryName = "Sữa & Sản phẩm từ sữa", Description = "Sữa tươi, sữa chua..." },
            new Category { CategoryId = 4, CategoryName = "Mì gói & Thực phẩm ăn liền", Description = "Mì ăn liền, phở khô..." },
            new Category { CategoryId = 5, CategoryName = "Gia vị & Dầu ăn", Description = "Nước mắm, hạt nêm..." }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(_categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Category>> SearchCategories(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return Ok(_categories);
            var result = _categories.Where(c => c.CategoryName.Contains(keyword, System.StringComparison.OrdinalIgnoreCase) ||
                                                (c.Description != null && c.Description.Contains(keyword, System.StringComparison.OrdinalIgnoreCase)));
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Category> CreateCategory(Category category)
        {
            category.CategoryId = _categories.Any() ? _categories.Max(c => c.CategoryId) + 1 : 1;
            _categories.Add(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Chỉ Admin mới có quyền cập nhật nhóm hàng/sản phẩm, Cashier bị chặn
        public IActionResult UpdateCategory(int id, Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (existingCategory == null) return NotFound();

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Description = category.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Chỉ Admin mới có quyền xóa sản phẩm/nhóm hàng, Cashier bị chặn
        public IActionResult DeleteCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null) return NotFound();

            _categories.Remove(category);
            return NoContent();
        }

        // 4. Kiểm tra quyền Admin (Chỉ tài khoản có Role = Admin mới được gọi)
        [HttpGet("admin-dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminDashboard() {
            return Ok(new { message = "Chào mừng Admin! Bạn có toàn quyền quản trị hệ thống siêu thị mini." });
        }

        // 5. Kiểm tra quyền chung cho nhân viên (Cả Admin và Cashier đều gọi được)
        [HttpGet("staff-pos")]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult GetStaffPos() {
            return Ok(new { message = "Màn hình POS Thu ngân sẵn sàng phục vụ bán hàng." });
        }
    }
}
