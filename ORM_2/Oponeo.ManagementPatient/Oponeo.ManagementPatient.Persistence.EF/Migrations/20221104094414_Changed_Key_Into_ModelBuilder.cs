using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oponeo.ManagementPatient.Persistence.EF.Migrations
{
    public partial class Changed_Key_Into_ModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: -1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { -1, "Jan", "Doctor" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BirthDate", "CreatedDateTime", "FirstName", "LastName", "UpdatedDateTime" },
                values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adam", "Patient", null });
        }
    }
}
