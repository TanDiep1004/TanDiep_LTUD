using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.DTOs;
using MiniSupermarket.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSupermarket.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase {
        private readonly Data.SupermarketDbContext _context;

        public UsersController(Data.SupermarketDbContext context) {
            _context = context;
        }

        // 1. GET: Lấy danh sách tài khoản người dùng qua UserResponseDto (Không lộ Password)
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var list = await _context.UserAccounts
                .AsNoTracking()
                .Select(u => new UserResponseDto {
                    Id = u.Id,
                    Username = u.Username,
                    FullName = u.FullName,
                    Role = u.Role,
                    IsActive = u.IsActive
                })
                .ToListAsync();
            return Ok(list);
        }

        // 2. POST: Thêm mới tài khoản người dùng (201 Created)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto) {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password)) {
                return BadRequest(new { message = "Tài khoản và mật khẩu không được để trống!" });
            }

            var username = dto.Username.Trim();
            if (await _context.UserAccounts.AnyAsync(u => u.Username.ToLower() == username.ToLower())) {
                return Conflict(new { message = "Tên đăng nhập đã tồn tại trong hệ thống!" });
            }

            var newUser = new UserAccount {
                Username = username,
                Password = dto.Password.Trim(),
                FullName = string.IsNullOrWhiteSpace(dto.FullName) ? username : dto.FullName.Trim(),
                Role = string.IsNullOrWhiteSpace(dto.Role) ? "Cashier" : dto.Role.Trim(),
                IsActive = true
            };

            _context.UserAccounts.Add(newUser);
            await _context.SaveChangesAsync();

            var responseDto = new UserResponseDto {
                Id = newUser.Id,
                Username = newUser.Username,
                FullName = newUser.FullName,
                Role = newUser.Role,
                IsActive = newUser.IsActive
            };

            return CreatedAtAction(nameof(GetAll), new { id = newUser.Id }, responseDto);
        }

        // 3. PUT: Đặt lại mật khẩu tài khoản về mặc định 123456
        [HttpPut("{username}/reset-password")]
        public async Task<IActionResult> ResetPassword(string username) {
            var acc = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            if (acc == null) {
                return NotFound(new { message = "Không tìm thấy tài khoản cần đặt lại mật khẩu!" });
            }
            
            acc.Password = "123456";
            await _context.SaveChangesAsync();
            return Ok(new { message = "Đặt lại mật khẩu thành công!" });
        }

        // 4. PUT: Khóa hoặc mở khóa tài khoản
        [HttpPut("{username}/toggle-status")]
        public async Task<IActionResult> ToggleStatus(string username) {
            var acc = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            if (acc == null) {
                return NotFound(new { message = "Không tìm thấy tài khoản cần cập nhật trạng thái!" });
            }
            
            acc.IsActive = !acc.IsActive;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Cập nhật trạng thái tài khoản thành công!" });
        }

        // 5. PUT: Cập nhật trực tiếp FullName, Role và IsActive của tài khoản từ bảng
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto dto) {
            var acc = await _context.UserAccounts.FindAsync(id);
            if (acc == null) {
                return NotFound(new { message = "Không tìm thấy tài khoản!" });
            }

            if (!string.IsNullOrWhiteSpace(dto.FullName)) {
                acc.FullName = dto.FullName.Trim();
            }
            if (!string.IsNullOrWhiteSpace(dto.Role)) {
                acc.Role = dto.Role.Trim();
            }
            acc.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();
            return Ok(new UserResponseDto {
                Id = acc.Id,
                Username = acc.Username,
                FullName = acc.FullName,
                Role = acc.Role,
                IsActive = acc.IsActive
            });
        }
    }

    public class UpdateUserDto {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Cashier";
        public bool IsActive { get; set; } = true;
    }

    public class CreateUserDto {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Cashier";
    }
}
