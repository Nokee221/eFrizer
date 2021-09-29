using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class reservarion_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Reservation",
                newName: "From");

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "To",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Reservation",
                newName: "Time");
        }
    }
}
