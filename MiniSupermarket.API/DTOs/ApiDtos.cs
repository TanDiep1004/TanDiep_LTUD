using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniSupermarket.API.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên nhóm hàng không được để trống!")]
        [StringLength(100, ErrorMessage = "Tên nhóm hàng không vượt quá 100 ký tự")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Tên khách hàng không được để trống!")]
        [StringLength(100, ErrorMessage = "Tên khách hàng không vượt quá 100 ký tự!")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [StringLength(15, ErrorMessage = "Số điện thoại không vượt quá 15 ký tự!")]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Address { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Điểm tích lũy không được âm!")]
        public int RewardPoints { get; set; } = 0;

        [StringLength(50)]
        public string MembershipRank { get; set; } = "Chuẩn";
    }

    public class SaveProductDto
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Mã vạch sản phẩm không được trống")]
        [StringLength(50)]
        public string Barcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 0!")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho không được âm!")]
        public int StockQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }

    public class PagedResultDto<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }

    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CashierUsername { get; set; } = string.Empty;
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; } = "Khách vãng lai";
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = "Tiền mặt";
        public List<OrderDetailResponseDto> Items { get; set; } = new();
    }

    public class OrderDetailResponseDto
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal => Quantity * UnitPrice;
    }

    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
