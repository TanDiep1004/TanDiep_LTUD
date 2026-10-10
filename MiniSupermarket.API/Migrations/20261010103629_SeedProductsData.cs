using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "8936036010015", 1, 12000m, "Snack khoai tây Lay's tự nhiên 56g", 100 },
                    { 2, "8936036010022", 1, 55000m, "Bánh ChocoPie Orion hộp 12 cái 360g", 50 },
                    { 3, "8936036010039", 1, 32000m, "Kẹo dẻo Chupa Chups lốc 10 gói", 80 },
                    { 4, "8936036020014", 2, 10000m, "Nước ngọt Coca-Cola lon 320ml", 200 },
                    { 5, "8936036020021", 2, 11000m, "Trà xanh Không Độ chai 455ml", 150 },
                    { 6, "8936036020038", 2, 6000m, "Nước khoáng Lavie chai 500ml", 250 },
                    { 7, "8936036030013", 3, 35000m, "Sữa tươi Vinamilk có đường lốc 4 hộp 180ml", 120 },
                    { 8, "8936036030020", 3, 26000m, "Sữa chua Vinamilk có đường lốc 4 hộp", 90 },
                    { 9, "8936036030037", 3, 42000m, "Phô mai Con Bò Cười hộp 8 miếng 112g", 60 },
                    { 10, "8936036040012", 4, 4500m, "Mì Hảo Hảo tôm chua cay gói 75g", 500 },
                    { 11, "8936036040029", 4, 8500m, "Mì Omachi sườn hầm ngũ quả gói 80g", 300 },
                    { 12, "8936036040036", 4, 9000m, "Phở bò khô Cung Đình gói 68g", 180 },
                    { 13, "8936036050011", 5, 58000m, "Dầu ăn Simply đậu nành chai 1 lít", 70 },
                    { 14, "8936036050028", 5, 28000m, "Nước mắm Nam Ngư Đệ Nhị chai 900ml", 110 },
                    { 15, "8936036050035", 5, 38000m, "Hạt nêm Knorr thịt thăn xương ống 400g", 85 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);
        }
    }
}
