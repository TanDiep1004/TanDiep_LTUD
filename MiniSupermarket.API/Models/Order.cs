using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MiniSupermarket.API.Models {
    [Table("Orders")]
    public class Order {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Tài khoản thu ngân không được để trống!")]
        [StringLength(50)]
        public string CashierUsername { get; set; } = string.Empty;

        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền hóa đơn không hợp lệ!")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; } = "Tiền mặt";

        // Quan hệ 1 - N: Một hóa đơn có nhiều chi tiết hóa đơn
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
