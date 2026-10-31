using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private static readonly List<Role> _roles = new List<Role>
        {
            new Role { RoleId = 1, RoleName = "Admin", Description = "Quản trị viên hệ thống" },
            new Role { RoleId = 2, RoleName = "Manager", Description = "Quản lý cửa hàng" },
            new Role { RoleId = 3, RoleName = "Cashier", Description = "Nhân viên thu ngân" },
            new Role { RoleId = 4, RoleName = "Warehouse", Description = "Nhân viên thủ kho" }
        };

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await Task.FromResult(_roles.ToList());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await Task.FromResult(_roles.FirstOrDefault(r => r.RoleId == id));
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy chức vụ!" });
            }
            return Ok(role);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa!" });
            }
            var result = await Task.FromResult(_roles
                .Where(r => r.RoleName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role newRole)
        {
            if (string.IsNullOrWhiteSpace(newRole.RoleName))
            {
                return BadRequest(new { message = "Tên chức vụ không được trống!" });
            }
            newRole.RoleId = _roles.Count > 0 ? _roles.Max(r => r.RoleId) + 1 : 1;
            _roles.Add(newRole);
            await Task.CompletedTask;
            return CreatedAtAction(nameof(GetById), new { id = newRole.RoleId }, newRole);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Role updateRole)
        {
            var role = await Task.FromResult(_roles.FirstOrDefault(r => r.RoleId == id));
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy chức vụ cần sửa!" });
            }
            role.RoleName = updateRole.RoleName;
            role.Description = updateRole.Description;
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await Task.FromResult(_roles.FirstOrDefault(r => r.RoleId == id));
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy chức vụ cần xóa!" });
            }
            _roles.Remove(role);
            return Ok(new { message = "Đã xóa chức vụ thành công!", deletedId = id });
        }
    }
}
