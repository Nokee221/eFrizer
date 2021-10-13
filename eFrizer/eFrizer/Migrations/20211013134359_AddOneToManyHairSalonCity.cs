using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class AddOneToManyHairSalonCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "HairSalons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HairSalons_CityId",
                table: "HairSalons",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HairSalons_Cities_CityId",
                table: "HairSalons",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairSalons_Cities_CityId",
                table: "HairSalons");

            migrationBuilder.DropIndex(
                name: "IX_HairSalons_CityId",
                table: "HairSalons");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "HairSalons");
        }
    }
}
