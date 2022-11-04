using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oponeo.ManagementPatient.Persistence.EF.Migrations
{
    public partial class EmptyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "BirthDate", "FirstName", "LastName" },
                values: new object[] { DateTime.Now.AddYears(-18), "Pawel", "Testowy" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
