using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oponeo.EF_CodeFirst.ConsoleApp.Migrations
{
    public partial class Added_TaxIdentifier_To_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaxIdentifier",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxIdentifier",
                table: "Customers");
        }
    }
}
