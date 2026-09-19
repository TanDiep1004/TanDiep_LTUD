using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private static readonly List<Role> _roles = new List<Role>
        {
            new Role { RoleId = 1, RoleName = "Admin", Description = "Quản trị viên hệ thống" },
            new Role { RoleId = 2, RoleName = "Manager", Description = "Quản lý cửa hàng" },
            new Role { RoleId = 3, RoleName = "Cashier", Description = "Nhân viên thu ngân" },
            new Role { RoleId = 4, RoleName = "StockKeeper", Description = "Nhân viên kho" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var role = _roles.FirstOrDefault(r => r.RoleId == id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy chức vụ!" });
            }
            return Ok(role);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa!" });
            }
            var result = _roles
                .Where(r => r.RoleName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Role newRole)
        {
            if (string.IsNullOrWhiteSpace(newRole.RoleName))
            {
                return BadRequest(new { message = "Tên chức vụ không được trống!" });
            }
            newRole.RoleId = _roles.Count > 0 ? _roles.Max(r => r.RoleId) + 1 : 1;
            _roles.Add(newRole);
            return CreatedAtAction(nameof(GetById), new { id = newRole.RoleId }, newRole);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Role updateRole)
        {
            var role = _roles.FirstOrDefault(r => r.RoleId == id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy chức vụ cần sửa!" });
            }
            role.RoleName = updateRole.RoleName;
            role.Description = updateRole.Description;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var role = _roles.FirstOrDefault(r => r.RoleId == id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy chức vụ cần xóa!" });
            }
            _roles.Remove(role);
            return NoContent();
        }
    }
}
