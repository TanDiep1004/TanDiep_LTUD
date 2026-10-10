using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models {
    [Table("UserAccounts")]
    public class UserAccount {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được trống")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được trống")]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ và tên không được trống")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "Cashier";

        public bool IsActive { get; set; } = true;
    }
}
