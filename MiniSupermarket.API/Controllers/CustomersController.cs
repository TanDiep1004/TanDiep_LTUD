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
    public class CustomersController : ControllerBase {
        private readonly SupermarketDbContext _context;

        public CustomersController(SupermarketDbContext context) {
            _context = context;
        }

        // 1. GET: Lấy toàn bộ danh sách khách hàng qua CustomerDto
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var list = await _context.Customers
                .AsNoTracking()
                .Select(c => new CustomerDto {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    RewardPoints = c.RewardPoints,
                    MembershipRank = c.MembershipRank
                })
                .ToListAsync();
            return Ok(list);
        }

        // 2. GET: Lấy chi tiết khách hàng theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var c = await _context.Customers.FindAsync(id);
            if (c == null) {
                return NotFound(new { message = "Không tìm thấy khách hàng trong CSDL!" });
            }
            return Ok(new CustomerDto {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                RewardPoints = c.RewardPoints,
                MembershipRank = c.MembershipRank
            });
        }

        // 3. SEARCH: Tìm kiếm khách hàng theo Tên hoặc Số điện thoại bằng LINQ (.Contains)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword) {
            if (string.IsNullOrWhiteSpace(keyword)) {
                return BadRequest(new { message = "Vui lòng nhập từ khóa tìm kiếm!" });
            }

            var result = await _context.Customers
                .AsNoTracking()
                .Where(c => c.CustomerName.Contains(keyword) || c.PhoneNumber.Contains(keyword))
                .Select(c => new CustomerDto {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    RewardPoints = c.RewardPoints,
                    MembershipRank = c.MembershipRank
                })
                .ToListAsync();
            return Ok(result);
        }

        // 4. POST: Thêm mới khách hàng thành viên (201 Created)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto dto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var newCustomer = new Customer {
                CustomerName = dto.CustomerName,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                RewardPoints = dto.RewardPoints,
                MembershipRank = string.IsNullOrWhiteSpace(dto.MembershipRank) ? "Chuẩn" : dto.MembershipRank
            };

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            dto.CustomerId = newCustomer.CustomerId;
            return CreatedAtAction(nameof(GetById), new { id = newCustomer.CustomerId }, dto);
        }

        // 5. PUT: Cập nhật thông tin khách hàng
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerDto updateDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) {
                return NotFound(new { message = "Không tìm thấy khách hàng cần cập nhật!" });
            }

            customer.CustomerName = updateDto.CustomerName;
            customer.PhoneNumber = updateDto.PhoneNumber;
            customer.Address = updateDto.Address;
            customer.RewardPoints = updateDto.RewardPoints;
            customer.MembershipRank = updateDto.MembershipRank;

            await _context.SaveChangesAsync();
            return Ok(updateDto);
        }

        // 6. DELETE: Xóa khách hàng (Chỉ Admin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) {
                return NotFound(new { message = "Không tìm thấy khách hàng cần xóa!" });
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Đã xóa khách hàng thành công!", deletedId = id });
        }
    }
}
