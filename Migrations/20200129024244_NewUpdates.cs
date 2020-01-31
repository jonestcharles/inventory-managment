using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class NewUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_UniqInventory",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Bins_BinName",
                table: "Bins");

            migrationBuilder.AlterColumn<string>(
                name: "UniqInventory",
                table: "Inventories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Inventories_UniqInventory",
                table: "Inventories",
                column: "UniqInventory");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Bins_BinName",
                table: "Bins",
                column: "BinName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Orders_OrderNumber",
                table: "Orders");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Inventories_UniqInventory",
                table: "Inventories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Bins_BinName",
                table: "Bins");

            migrationBuilder.AlterColumn<string>(
                name: "UniqInventory",
                table: "Inventories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

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
    }
}
