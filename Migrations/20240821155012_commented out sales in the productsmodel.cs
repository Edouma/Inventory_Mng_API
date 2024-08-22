using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Mngt_API.Migrations
{
    /// <inheritdoc />
    public partial class commentedoutsalesintheproductsmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MakeSaleModel_Products_ProductId",
                table: "MakeSaleModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MakeSaleModel",
                table: "MakeSaleModel");

            migrationBuilder.RenameTable(
                name: "MakeSaleModel",
                newName: "Sales");

            migrationBuilder.RenameIndex(
                name: "IX_MakeSaleModel_ProductId",
                table: "Sales",
                newName: "IX_Sales_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "MakeSaleModel");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_ProductId",
                table: "MakeSaleModel",
                newName: "IX_MakeSaleModel_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MakeSaleModel",
                table: "MakeSaleModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MakeSaleModel_Products_ProductId",
                table: "MakeSaleModel",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
