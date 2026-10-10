using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Models;
using System.Linq;

namespace MiniSupermarket.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase {
        private readonly Data.SupermarketDbContext _context;

        public UsersController(Data.SupermarketDbContext context) {
            _context = context;
        }

        // 1. GET: Lấy danh sách tài khoản người dùng
        [HttpGet]
        public IActionResult GetAll() {
            var list = _context.UserAccounts.Select(u => new {
                u.Id,
                u.Username,
                u.FullName,
                u.Role,
                u.IsActive
            }).ToList();
            return Ok(list);
        }

        // 2. POST: Thêm mới tài khoản người dùng
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto dto) {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password)) {
                return BadRequest(new { message = "Tài khoản và mật khẩu không được để trống!" });
            }

            var username = dto.Username.Trim();
            if (_context.UserAccounts.Any(u => u.Username.ToLower() == username.ToLower())) {
                return Conflict(new { message = "Tên đăng nhập đã tồn tại trong hệ thống!" });
            }

            var newUser = new UserAccount {
                Username = username,
                Password = dto.Password.Trim(),
                FullName = dto.FullName?.Trim() ?? username,
                Role = dto.Role?.Trim() ?? "Cashier",
                IsActive = true
            };

            _context.UserAccounts.Add(newUser);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = newUser.Id }, newUser);
        }

        // 3. PUT: Đặt lại mật khẩu tài khoản về mặc định 123456
        [HttpPut("{username}/reset-password")]
        public IActionResult ResetPassword(string username) {
            var acc = _context.UserAccounts.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
            if (acc == null) {
                return NotFound(new { message = "Không tìm thấy tài khoản cần đặt lại mật khẩu!" });
            }
            
            acc.Password = "123456";
            _context.SaveChanges();
            return Ok(new { message = "Đặt lại mật khẩu thành công!" });
        }

        // 4. PUT: Khóa hoặc mở khóa tài khoản
        [HttpPut("{username}/toggle-status")]
        public IActionResult ToggleStatus(string username) {
            var acc = _context.UserAccounts.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
            if (acc == null) {
                return NotFound(new { message = "Không tìm thấy tài khoản cần cập nhật trạng thái!" });
            }
            
            acc.IsActive = !acc.IsActive;
            _context.SaveChanges();
            return Ok(new { message = "Cập nhật trạng thái tài khoản thành công!" });
        }
    }

    public class CreateUserDto {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Cashier";
    }
}
