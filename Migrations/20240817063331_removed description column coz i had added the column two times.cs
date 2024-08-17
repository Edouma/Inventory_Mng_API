﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Mngt_API.Migrations
{
    /// <inheritdoc />
    public partial class removeddescriptioncolumncozihadaddedthecolumntwotimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
