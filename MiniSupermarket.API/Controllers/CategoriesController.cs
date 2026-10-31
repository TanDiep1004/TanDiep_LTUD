using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.DTOs;
using MiniSupermarket.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSupermarket.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase {
        private readonly SupermarketDbContext _context;

        // Tiêm DbContext thông qua Constructor Injection
        public CategoriesController(SupermarketDbContext context) {
            _context = context;
        }

        // 1. READ: Lấy toàn bộ danh mục từ SQL Server qua CategoryDto
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var list = await _context.Categories
                .AsNoTracking()
                .Select(c => new CategoryDto {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
            return Ok(list);
        }

        // 2. READ: Lấy chi tiết 1 danh mục theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var c = await _context.Categories.FindAsync(id);
            if (c == null) {
                return NotFound(new { message = "Không tìm thấy nhóm hàng trong CSDL!" });
            }
            return Ok(new CategoryDto {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description
            });
        }

        // 3. SEARCH: Tìm kiếm qua Query String bằng LINQ (.Contains)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? keyword = null) {
            var query = _context.Categories.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                string kw = keyword.Trim();
                query = query.Where(c => c.CategoryName.Contains(kw) || (c.Description != null && c.Description.Contains(kw)));
            }
            var result = await query
                .Select(c => new CategoryDto {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
            return Ok(result);
        }

        // 4. CREATE: Thêm mới nhóm hàng vào Database (Admin & Warehouse)
        [HttpPost]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Create([FromBody] CategoryDto dto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var newCat = new Category {
                CategoryName = dto.CategoryName,
                Description = dto.Description
            };

            _context.Categories.Add(newCat);
            await _context.SaveChangesAsync();

            dto.CategoryId = newCat.CategoryId;
            return CreatedAtAction(nameof(GetById), new { id = newCat.CategoryId }, dto);
        }

        // 5. UPDATE: Cập nhật nhóm hàng vào Database (Admin & Warehouse)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDto updateDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var cat = await _context.Categories.FindAsync(id);
            if (cat == null) {
                return NotFound(new { message = "Không tìm thấy nhóm hàng cần sửa!" });
            }

            cat.CategoryName = updateDto.CategoryName;
            cat.Description = updateDto.Description;

            await _context.SaveChangesAsync();
            return Ok(new CategoryDto {
                CategoryId = cat.CategoryId,
                CategoryName = cat.CategoryName,
                Description = cat.Description
            });
        }

        // 6. DELETE: Xóa nhóm hàng khỏi Database (Chỉ Admin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null) {
                return NotFound(new { message = "Không tìm thấy nhóm hàng cần xóa!" });
            }

            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Đã xóa nhóm hàng thành công!", deletedId = id });
        }

        // 7. Kiểm tra quyền Admin (Chỉ tài khoản có Role = Admin mới được gọi)
        [HttpGet("admin-dashboard")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminDashboard() {
            int totalCategories = await _context.Categories.CountAsync();
            return Ok(new { message = "Chào mừng Admin! Bạn có toàn quyền quản trị hệ thống siêu thị mini.", totalCategories });
        }

        // 8. Kiểm tra quyền chung cho nhân viên (Cả Admin và Cashier đều gọi được)
        [HttpGet("staff-pos")]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<IActionResult> GetStaffPos() {
            int totalProducts = await _context.Products.CountAsync();
            return Ok(new { message = "Màn hình POS Thu ngân sẵn sàng phục vụ bán hàng.", totalProducts });
        }
    }
}
