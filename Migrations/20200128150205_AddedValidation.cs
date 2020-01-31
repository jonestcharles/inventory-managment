using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class AddedValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqInventory",
                table: "Inventories",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_SKU",
                table: "Products",
                column: "SKU");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UniqInventory",
                table: "Inventories",
                column: "UniqInventory",
                unique: true,
                filter: "[UniqInventory] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_BinName",
                table: "Bins",
                column: "BinName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_SKU",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_UniqInventory",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Bins_BinName",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "UniqInventory",
                table: "Inventories");
        }
    }
}
