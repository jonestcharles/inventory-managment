using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class UpdateInventories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Inventories_UniqInventory",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_BinID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "UniqInventory",
                table: "Inventories");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BinID_ProductID",
                table: "Inventories",
                columns: new[] { "BinID", "ProductID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inventories_BinID_ProductID",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "UniqInventory",
                table: "Inventories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Inventories_UniqInventory",
                table: "Inventories",
                column: "UniqInventory");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BinID",
                table: "Inventories",
                column: "BinID");
        }
    }
}
