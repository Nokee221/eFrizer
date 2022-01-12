using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class MovePriceDescriptionAndTimeFromServiceToHairSalonService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "TimeMin",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HairSalonServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "HairSalonServices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TimeMin",
                table: "HairSalonServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "HairSalonServices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "HairSalonServices");

            migrationBuilder.DropColumn(
                name: "TimeMin",
                table: "HairSalonServices");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Services",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TimeMin",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
