using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class ProductIdOrdersIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "OrdersIngredients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.AddColumn<int>(
                name: "IsPaid",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrdersIngredients");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Orders");
            
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Orders");
        }
    }
}
