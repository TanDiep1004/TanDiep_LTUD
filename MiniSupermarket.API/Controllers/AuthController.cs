using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MiniSupermarket.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration) {
            _configuration = configuration;
        }

        // Endpoint Đăng nhập: POST /api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request) {
            // Kiểm tra tài khoản mẫu (không phân biệt chữ hoa/thường)
            string user = request.Username?.Trim() ?? string.Empty;
            string pass = request.Password?.Trim() ?? string.Empty;

            if (string.Equals(user, "admin", StringComparison.OrdinalIgnoreCase) && (pass == "1234567" || pass == "123456")) {
                var token = GenerateJwtToken(user, "Admin");
                return Ok(new { success = true, token = token, role = "Admin" });
            } else if (string.Equals(user, "cashier", StringComparison.OrdinalIgnoreCase) && (pass == "1234567" || pass == "123456")) {
                var token = GenerateJwtToken(user, "Cashier");
                return Ok(new { success = true, token = token, role = "Cashier" });
            }
            return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
        }

        private string GenerateJwtToken(string username, string role) {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Lấy khóa bí mật từ appsettings.json
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!");
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequestDto {
        [Required(ErrorMessage = "Tài khoản không được để trống!")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        public string Password { get; set; } = string.Empty;
    }
}
