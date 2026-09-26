using System.ComponentModel.DataAnnotations;

namespace MiniSupermarket.API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên nhóm hàng không được để trống!")]
        [StringLength(100, ErrorMessage = "Tên nhóm hàng không quá 100 ký tự!")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "Mô tả không quá 255 ký tự!")]
        public string? Description { get; set; }
    }
}
