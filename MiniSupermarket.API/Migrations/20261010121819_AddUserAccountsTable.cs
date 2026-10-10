using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAccountsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "Snack, bánh quy, kẹo sô cô la");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Nước giải khát & Nước ngọt", "Nước ngọt, nước khoáng, trà đóng chai, nước tăng lực" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Sữa tươi, sữa chua, bơ, phô mai");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Mì gói & Thực phẩm khô", "Mì ăn liền, phở khô, bún, miến, cháo gói" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm, hạt nêm, dầu thực vật, đường, muối, tiêu");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 6, "Gạo, Bột & Nông sản khô", "Gạo thơm ST25, đậu các loại, nấm hương, mộc nhĩ" },
                    { 7, "Thực phẩm đông lạnh", "Cá viên, bò viên, xúc xích, nem chua rán, sủi cảo" },
                    { 8, "Đồ hộp & Thực phẩm chế biến", "Thịt heo hộp, cá ngừ sốt cà, pa-tê, xúc xích tiệt trùng" },
                    { 9, "Trà, Cà phê & Thức uống hòa tan", "Trà túi lọc, cà phê đen, cà phê hòa tan 3in1, cacao" },
                    { 10, "Hóa phẩm & Tẩy rửa gia dụng", "Nước rửa chén, bột giặt, nước xả vải, nước lau sàn" },
                    { 11, "Chăm sóc cá nhân & Cơ thể", "Dầu gội, sữa tắm, kem đánh răng, sữa rửa mặt" },
                    { 12, "Giấy & Khăn ướt tiện lợi", "Giấy vệ sinh cuộn, khăn giấy rút, khăn ướt kháng khuẩn" },
                    { 13, "Đồ dùng gia đình & Nhà bếp", "Màng bọc thực phẩm, túi rác, chén dĩa, đũa muỗng" },
                    { 14, "Rau củ & Trái cây tươi sạch", "Rau xanh các loại, củ quả, táo, cam, chuối tươi theo ngày" },
                    { 15, "Văn phòng phẩm & Tiện ích nhỏ", "Bút viết, tập học sinh, pin tiểu, băng keo, bật lửa" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 16, "8936036010046", 1, 125000m, "Bánh quy bơ Danisa hộp thiếc 454g", 30 },
                    { 17, "8936036020045", 2, 14000m, "Nước tăng lực Red Bull lon 250ml", 180 },
                    { 18, "8936036030044", 3, 62000m, "Bơ lạt tự nhiên TH true BUTTER hộp 200g", 40 },
                    { 19, "8936036040043", 4, 11000m, "Bún bò Huế khô Vifon gói 80g", 200 },
                    { 20, "8936036050042", 5, 15000m, "Tương ớt Chinsu chai 250g", 150 }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "FullName", "IsActive", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Nguyễn Quản Trị", true, "123456", "Admin", "admin01" },
                    { 2, "Trần Giám Đốc", true, "123456", "Admin", "admin02" },
                    { 3, "Lê Thu Ngân", true, "123456", "Cashier", "cashier01" },
                    { 4, "Phạm Bán Hàng", true, "123456", "Cashier", "cashier02" },
                    { 5, "Hoàng Thu Ngân", true, "123456", "Cashier", "cashier03" },
                    { 6, "Vũ Thị Quầy", true, "123456", "Cashier", "cashier04" },
                    { 7, "Đỗ Bán Lẻ", true, "123456", "Cashier", "cashier05" },
                    { 8, "Ngô Quản Kho", true, "123456", "Warehouse", "ware01" },
                    { 9, "Bùi Kiểm Kê", true, "123456", "Warehouse", "ware02" },
                    { 10, "Dương Thủ Kho", true, "123456", "Warehouse", "ware03" },
                    { 11, "Lý Nhập Hàng", true, "123456", "Warehouse", "ware04" },
                    { 12, "Đặng Hỗ Trợ", true, "123456", "Admin", "admin_backup" },
                    { 13, "Hồ Ca Chiều", true, "123456", "Cashier", "cashier06" },
                    { 14, "Trương Vận Chuyển", true, "123456", "Warehouse", "ware05" },
                    { 15, "Mai Giám Sát", true, "123456", "Admin", "supervisor" },
                    { 16, "Admin Quản Trị", true, "123456", "Admin", "admin" },
                    { 17, "Thu Ngân POS", true, "123456", "Cashier", "cashier" },
                    { 18, "van an", true, "123456", "Admin", "hhh" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 21, "8936036060010", 6, 185000m, "Gạo thơm thượng hạng ST25 túi 5kg", 50 },
                    { 22, "8936036070019", 7, 48000m, "Cá viên chiên CP gói 500g", 75 },
                    { 23, "8936036080018", 8, 32000m, "Cá ngừ ngâm dầu Hạ Long hộp 175g", 90 },
                    { 24, "8936036090017", 9, 56000m, "Cà phê G7 3in1 Trung Nguyên hộp 18 gói", 120 },
                    { 25, "8936036100013", 10, 29000m, "Nước rửa chén Sunlight chanh chai 750g", 85 },
                    { 26, "8936036110012", 11, 165000m, "Dầu gội Clear Bạc Hà sạch gàu chai 630g", 45 },
                    { 27, "8936036120011", 12, 78000m, "Giấy vệ sinh Pulppy lốc 10 cuộn 3 lớp", 60 },
                    { 28, "8936036130010", 13, 45000m, "Màng bọc thực phẩm PE Sunhouse 30cmx150m", 55 },
                    { 29, "8936036140019", 14, 89000m, "Táo Envy New Zealand tươi khay 4 quả", 35 },
                    { 30, "8936036150018", 15, 36000m, "Pin AA Energizer Max vỉ 2 viên", 110 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "Snack, bánh quy, kẹo dẻo");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Nước giải khát & Trà", "Nước ngọt, nước khoáng, trà" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Sữa tươi, sữa chua, phô mai");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Mì gói & Thực phẩm ăn liền", "Mì ăn liền, phở khô, cháo gói" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm, hạt nêm, dầu thực vật");
        }
    }
}
