using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data {
    // DbContext đại diện cho phiên làm việc với cơ sở dữ liệu SQL Server
    public class SupermarketDbContext : DbContext {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        // Khai báo các bảng dữ liệu ánh xạ từ Model
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // Cấu hình dữ liệu mồi ban đầu (Data Seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Nạp sẵn 5 danh mục ban đầu vào SQL Server ngay khi tạo bảng
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Bánh kẹo & Đồ ăn vặt", Description = "Snack, bánh quy, kẹo dẻo" },
                new Category { CategoryId = 2, CategoryName = "Nước giải khát & Trà", Description = "Nước ngọt, nước khoáng, trà" },
                new Category { CategoryId = 3, CategoryName = "Sữa & Sản phẩm từ sữa", Description = "Sữa tươi, sữa chua, phô mai" },
                new Category { CategoryId = 4, CategoryName = "Mì gói & Thực phẩm ăn liền", Description = "Mì ăn liền, phở khô, cháo gói" },
                new Category { CategoryId = 5, CategoryName = "Gia vị & Dầu ăn", Description = "Nước mắm, hạt nêm, dầu thực vật" }
            );

            // Nạp sẵn 3 khách hàng mẫu vào SQL Server
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn A", PhoneNumber = "0901122334", MembershipRank = "Vàng", RewardPoints = 150, Address = "TP. Hồ Chí Minh" },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị B", PhoneNumber = "0918877665", MembershipRank = "Bạc", RewardPoints = 50, Address = "Hà Nội" },
                new Customer { CustomerId = 3, CustomerName = "Lê Văn C", PhoneNumber = "0983344556", MembershipRank = "Chuẩn", RewardPoints = 10, Address = "Đà Nẵng" }
            );

            // Nạp sẵn 15 sản phẩm mẫu vào SQL Server
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "8936036010015", ProductName = "Snack khoai tây Lay's tự nhiên 56g", Price = 12000, StockQuantity = 100, CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "8936036010022", ProductName = "Bánh ChocoPie Orion hộp 12 cái 360g", Price = 55000, StockQuantity = 50, CategoryId = 1 },
                new Product { ProductId = 3, Barcode = "8936036010039", ProductName = "Kẹo dẻo Chupa Chups lốc 10 gói", Price = 32000, StockQuantity = 80, CategoryId = 1 },
                new Product { ProductId = 4, Barcode = "8936036020014", ProductName = "Nước ngọt Coca-Cola lon 320ml", Price = 10000, StockQuantity = 200, CategoryId = 2 },
                new Product { ProductId = 5, Barcode = "8936036020021", ProductName = "Trà xanh Không Độ chai 455ml", Price = 11000, StockQuantity = 150, CategoryId = 2 },
                new Product { ProductId = 6, Barcode = "8936036020038", ProductName = "Nước khoáng Lavie chai 500ml", Price = 6000, StockQuantity = 250, CategoryId = 2 },
                new Product { ProductId = 7, Barcode = "8936036030013", ProductName = "Sữa tươi Vinamilk có đường lốc 4 hộp 180ml", Price = 35000, StockQuantity = 120, CategoryId = 3 },
                new Product { ProductId = 8, Barcode = "8936036030020", ProductName = "Sữa chua Vinamilk có đường lốc 4 hộp", Price = 26000, StockQuantity = 90, CategoryId = 3 },
                new Product { ProductId = 9, Barcode = "8936036030037", ProductName = "Phô mai Con Bò Cười hộp 8 miếng 112g", Price = 42000, StockQuantity = 60, CategoryId = 3 },
                new Product { ProductId = 10, Barcode = "8936036040012", ProductName = "Mì Hảo Hảo tôm chua cay gói 75g", Price = 4500, StockQuantity = 500, CategoryId = 4 },
                new Product { ProductId = 11, Barcode = "8936036040029", ProductName = "Mì Omachi sườn hầm ngũ quả gói 80g", Price = 8500, StockQuantity = 300, CategoryId = 4 },
                new Product { ProductId = 12, Barcode = "8936036040036", ProductName = "Phở bò khô Cung Đình gói 68g", Price = 9000, StockQuantity = 180, CategoryId = 4 },
                new Product { ProductId = 13, Barcode = "8936036050011", ProductName = "Dầu ăn Simply đậu nành chai 1 lít", Price = 58000, StockQuantity = 70, CategoryId = 5 },
                new Product { ProductId = 14, Barcode = "8936036050028", ProductName = "Nước mắm Nam Ngư Đệ Nhị chai 900ml", Price = 28000, StockQuantity = 110, CategoryId = 5 },
                new Product { ProductId = 15, Barcode = "8936036050035", ProductName = "Hạt nêm Knorr thịt thăn xương ống 400g", Price = 38000, StockQuantity = 85, CategoryId = 5 }
            );
        }
    }
}
