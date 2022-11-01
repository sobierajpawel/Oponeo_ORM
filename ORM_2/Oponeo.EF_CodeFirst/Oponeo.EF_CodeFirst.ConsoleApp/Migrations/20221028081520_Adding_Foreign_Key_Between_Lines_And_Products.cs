using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oponeo.EF_CodeFirst.ConsoleApp.Migrations
{
    public partial class Adding_Foreign_Key_Between_Lines_And_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderLine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_ProductId",
                table: "OrderLine",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Products_ProductId",
                table: "OrderLine",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Products_ProductId",
                table: "OrderLine");

            migrationBuilder.DropIndex(
                name: "IX_OrderLine_ProductId",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderLine");
        }
    }
}
