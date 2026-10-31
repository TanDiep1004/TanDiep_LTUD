using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MiniSupermarket.API.Models {
    [Table("OrderDetails")]
    public class OrderDetail {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        [JsonIgnore]
        public virtual Order? Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public virtual Product? Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng mua phải lớn hơn 0!")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Đơn giá bán phải lớn hơn 0!")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
    }
}
