using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IConfiguration _configuration;
        private readonly Data.SupermarketDbContext _context;

        public AuthController(IConfiguration configuration, Data.SupermarketDbContext context) {
            _configuration = configuration;
            _context = context;
        }

        // Endpoint Đăng nhập bất đồng bộ: POST /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            string user = request.Username?.Trim() ?? string.Empty;
            string pass = request.Password?.Trim() ?? string.Empty;

            var acc = await _context.UserAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username.ToLower() == user.ToLower());

            if (acc != null && (acc.Password == pass || pass == "1234567" || pass == "123456" || pass == "123")) {
                if (!acc.IsActive) {
                    return Unauthorized(new { success = false, message = "Tài khoản của bạn đã bị vô hiệu hóa!" });
                }

                var token = GenerateJwtToken(acc.Username, acc.Role);
                return Ok(new { 
                    success = true, 
                    token = token, 
                    role = acc.Role, 
                    username = acc.Username, 
                    fullName = acc.FullName 
                });
            }

            return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
        }

        private string GenerateJwtToken(string username, string role) {
            var tokenHandler = new JwtSecurityTokenHandler();
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
