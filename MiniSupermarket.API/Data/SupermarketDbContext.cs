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
        public DbSet<UserAccount> UserAccounts { get; set; }

        // Cấu hình dữ liệu mồi ban đầu (Data Seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Nạp sẵn 15 danh mục chuẩn vào SQL Server
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Bánh kẹo & Đồ ăn vặt", Description = "Snack, bánh quy, kẹo sô cô la" },
                new Category { CategoryId = 2, CategoryName = "Nước giải khát & Nước ngọt", Description = "Nước ngọt, nước khoáng, trà đóng chai, nước tăng lực" },
                new Category { CategoryId = 3, CategoryName = "Sữa & Sản phẩm từ sữa", Description = "Sữa tươi, sữa chua, bơ, phô mai" },
                new Category { CategoryId = 4, CategoryName = "Mì gói & Thực phẩm khô", Description = "Mì ăn liền, phở khô, bún, miến, cháo gói" },
                new Category { CategoryId = 5, CategoryName = "Gia vị & Dầu ăn", Description = "Nước mắm, hạt nêm, dầu thực vật, đường, muối, tiêu" },
                new Category { CategoryId = 6, CategoryName = "Gạo, Bột & Nông sản khô", Description = "Gạo thơm ST25, đậu các loại, nấm hương, mộc nhĩ" },
                new Category { CategoryId = 7, CategoryName = "Thực phẩm đông lạnh", Description = "Cá viên, bò viên, xúc xích, nem chua rán, sủi cảo" },
                new Category { CategoryId = 8, CategoryName = "Đồ hộp & Thực phẩm chế biến", Description = "Thịt heo hộp, cá ngừ sốt cà, pa-tê, xúc xích tiệt trùng" },
                new Category { CategoryId = 9, CategoryName = "Trà, Cà phê & Thức uống hòa tan", Description = "Trà túi lọc, cà phê đen, cà phê hòa tan 3in1, cacao" },
                new Category { CategoryId = 10, CategoryName = "Hóa phẩm & Tẩy rửa gia dụng", Description = "Nước rửa chén, bột giặt, nước xả vải, nước lau sàn" },
                new Category { CategoryId = 11, CategoryName = "Chăm sóc cá nhân & Cơ thể", Description = "Dầu gội, sữa tắm, kem đánh răng, sữa rửa mặt" },
                new Category { CategoryId = 12, CategoryName = "Giấy & Khăn ướt tiện lợi", Description = "Giấy vệ sinh cuộn, khăn giấy rút, khăn ướt kháng khuẩn" },
                new Category { CategoryId = 13, CategoryName = "Đồ dùng gia đình & Nhà bếp", Description = "Màng bọc thực phẩm, túi rác, chén dĩa, đũa muỗng" },
                new Category { CategoryId = 14, CategoryName = "Rau củ & Trái cây tươi sạch", Description = "Rau xanh các loại, củ quả, táo, cam, chuối tươi theo ngày" },
                new Category { CategoryId = 15, CategoryName = "Văn phòng phẩm & Tiện ích nhỏ", Description = "Bút viết, tập học sinh, pin tiểu, băng keo, bật lửa" }
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
                new Product { ProductId = 15, Barcode = "8936036050035", ProductName = "Hạt nêm Knorr thịt thăn xương ống 400g", Price = 38000, StockQuantity = 85, CategoryId = 5 },
                // 15 sản phẩm mới bổ sung cho từng nhóm hàng (1 đến 15)
                new Product { ProductId = 16, Barcode = "8936036010046", ProductName = "Bánh quy bơ Danisa hộp thiếc 454g", Price = 125000, StockQuantity = 30, CategoryId = 1 },
                new Product { ProductId = 17, Barcode = "8936036020045", ProductName = "Nước tăng lực Red Bull lon 250ml", Price = 14000, StockQuantity = 180, CategoryId = 2 },
                new Product { ProductId = 18, Barcode = "8936036030044", ProductName = "Bơ lạt tự nhiên TH true BUTTER hộp 200g", Price = 62000, StockQuantity = 40, CategoryId = 3 },
                new Product { ProductId = 19, Barcode = "8936036040043", ProductName = "Bún bò Huế khô Vifon gói 80g", Price = 11000, StockQuantity = 200, CategoryId = 4 },
                new Product { ProductId = 20, Barcode = "8936036050042", ProductName = "Tương ớt Chinsu chai 250g", Price = 15000, StockQuantity = 150, CategoryId = 5 },
                new Product { ProductId = 21, Barcode = "8936036060010", ProductName = "Gạo thơm thượng hạng ST25 túi 5kg", Price = 185000, StockQuantity = 50, CategoryId = 6 },
                new Product { ProductId = 22, Barcode = "8936036070019", ProductName = "Cá viên chiên CP gói 500g", Price = 48000, StockQuantity = 75, CategoryId = 7 },
                new Product { ProductId = 23, Barcode = "8936036080018", ProductName = "Cá ngừ ngâm dầu Hạ Long hộp 175g", Price = 32000, StockQuantity = 90, CategoryId = 8 },
                new Product { ProductId = 24, Barcode = "8936036090017", ProductName = "Cà phê G7 3in1 Trung Nguyên hộp 18 gói", Price = 56000, StockQuantity = 120, CategoryId = 9 },
                new Product { ProductId = 25, Barcode = "8936036100013", ProductName = "Nước rửa chén Sunlight chanh chai 750g", Price = 29000, StockQuantity = 85, CategoryId = 10 },
                new Product { ProductId = 26, Barcode = "8936036110012", ProductName = "Dầu gội Clear Bạc Hà sạch gàu chai 630g", Price = 165000, StockQuantity = 45, CategoryId = 11 },
                new Product { ProductId = 27, Barcode = "8936036120011", ProductName = "Giấy vệ sinh Pulppy lốc 10 cuộn 3 lớp", Price = 78000, StockQuantity = 60, CategoryId = 12 },
                new Product { ProductId = 28, Barcode = "8936036130010", ProductName = "Màng bọc thực phẩm PE Sunhouse 30cmx150m", Price = 45000, StockQuantity = 55, CategoryId = 13 },
                new Product { ProductId = 29, Barcode = "8936036140019", ProductName = "Táo Envy New Zealand tươi khay 4 quả", Price = 89000, StockQuantity = 35, CategoryId = 14 },
                new Product { ProductId = 30, Barcode = "8936036150018", ProductName = "Pin AA Energizer Max vỉ 2 viên", Price = 36000, StockQuantity = 110, CategoryId = 15 }
            );

            // Nạp sẵn danh sách tài khoản phân quyền vào SQL Server
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount { Id = 1, Username = "admin01", Password = "123456", FullName = "Nguyễn Quản Trị", Role = "Admin", IsActive = true },
                new UserAccount { Id = 2, Username = "admin02", Password = "123456", FullName = "Trần Giám Đốc", Role = "Admin", IsActive = true },
                new UserAccount { Id = 3, Username = "cashier01", Password = "123456", FullName = "Lê Thu Ngân", Role = "Cashier", IsActive = true },
                new UserAccount { Id = 4, Username = "cashier02", Password = "123456", FullName = "Phạm Bán Hàng", Role = "Cashier", IsActive = true },
                new UserAccount { Id = 5, Username = "cashier03", Password = "123456", FullName = "Hoàng Thu Ngân", Role = "Cashier", IsActive = true },
                new UserAccount { Id = 6, Username = "cashier04", Password = "123456", FullName = "Vũ Thị Quầy", Role = "Cashier", IsActive = true },
                new UserAccount { Id = 7, Username = "cashier05", Password = "123456", FullName = "Đỗ Bán Lẻ", Role = "Cashier", IsActive = true },
                new UserAccount { Id = 8, Username = "ware01", Password = "123456", FullName = "Ngô Quản Kho", Role = "Warehouse", IsActive = true },
                new UserAccount { Id = 9, Username = "ware02", Password = "123456", FullName = "Bùi Kiểm Kê", Role = "Warehouse", IsActive = true },
                new UserAccount { Id = 10, Username = "ware03", Password = "123456", FullName = "Dương Thủ Kho", Role = "Warehouse", IsActive = true },
                new UserAccount { Id = 11, Username = "ware04", Password = "123456", FullName = "Lý Nhập Hàng", Role = "Warehouse", IsActive = true },
                new UserAccount { Id = 12, Username = "admin_backup", Password = "123456", FullName = "Đặng Hỗ Trợ", Role = "Admin", IsActive = true },
                new UserAccount { Id = 13, Username = "cashier06", Password = "123456", FullName = "Hồ Ca Chiều", Role = "Cashier", IsActive = true },
                new UserAccount { Id = 14, Username = "ware05", Password = "123456", FullName = "Trương Vận Chuyển", Role = "Warehouse", IsActive = true },
                new UserAccount { Id = 15, Username = "supervisor", Password = "123456", FullName = "Mai Giám Sát", Role = "Admin", IsActive = true },
                new UserAccount { Id = 16, Username = "admin", Password = "123456", FullName = "Admin Quản Trị", Role = "Admin", IsActive = true },
                new UserAccount { Id = 17, Username = "cashier", Password = "123456", FullName = "Thu Ngân POS", Role = "Cashier", IsActive = true },
                new UserAccount { Id = 18, Username = "hhh", Password = "123456", FullName = "van an", Role = "Admin", IsActive = true }
            );
        }
    }
}
