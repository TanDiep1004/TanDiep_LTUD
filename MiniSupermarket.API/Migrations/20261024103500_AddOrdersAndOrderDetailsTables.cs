using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersAndOrderDetailsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CashierUsername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CashierUsername", "CustomerId", "OrderDate", "PaymentMethod", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "cashier01", 1, new DateTime(2026, 10, 24, 8, 15, 0, 0, DateTimeKind.Unspecified), "Tiền mặt", 155000m },
                    { 2, "cashier01", null, new DateTime(2026, 10, 24, 9, 30, 0, 0, DateTimeKind.Unspecified), "Tiền mặt", 42000m },
                    { 3, "cashier02", 2, new DateTime(2026, 10, 24, 10, 45, 0, 0, DateTimeKind.Unspecified), "Chuyển khoản", 230000m },
                    { 4, "cashier03", 3, new DateTime(2026, 10, 24, 14, 10, 0, 0, DateTimeKind.Unspecified), "Tiền mặt", 370000m },
                    { 5, "cashier05", 1, new DateTime(2026, 10, 24, 16, 40, 0, 0, DateTimeKind.Unspecified), "Tiền mặt", 330000m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 2, 2, 55000m },
                    { 2, 1, 10, 10, 4500m },
                    { 3, 2, 9, 1, 42000m },
                    { 4, 3, 16, 1, 125000m },
                    { 5, 3, 7, 3, 35000m },
                    { 6, 4, 21, 2, 185000m },
                    { 7, 5, 26, 2, 165000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            // Khởi tạo Stored Procedure phục vụ báo cáo nhanh qua ADO.NET
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE sp_GetDailySalesSummary
    @ReportDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        COUNT(o.OrderId) AS TotalOrders,
        ISNULL(SUM(o.TotalAmount), 0) AS TotalRevenue
    FROM Orders o
    WHERE @ReportDate IS NULL OR CAST(o.OrderDate AS DATE) = @ReportDate;
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetDailySalesSummary;");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
