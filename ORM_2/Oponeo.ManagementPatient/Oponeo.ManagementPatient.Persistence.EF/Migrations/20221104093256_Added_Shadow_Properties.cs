using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oponeo.ManagementPatient.Persistence.EF.Migrations
{
    public partial class Added_Shadow_Properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Patients",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Patients");
        }
    }
}
