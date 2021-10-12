using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class AddedHSHDasDBset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairSalonHairDresser_ApplicationUsers_HairDresserId",
                table: "HairSalonHairDresser");

            migrationBuilder.DropForeignKey(
                name: "FK_HairSalonHairDresser_HairSalons_HairSalonId",
                table: "HairSalonHairDresser");

            migrationBuilder.RenameTable(
                name: "HairSalonHairDresser",
                newName: "HairSalonHairDressers");

            migrationBuilder.RenameIndex(
                name: "IX_HairSalonHairDresser_HairDresserId",
                table: "HairSalonHairDressers",
                newName: "IX_HairSalonHairDressers_HairDresserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HairSalonHairDressers_ApplicationUsers_HairDresserId",
                table: "HairSalonHairDressers",
                column: "HairDresserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HairSalonHairDressers_HairSalons_HairSalonId",
                table: "HairSalonHairDressers",
                column: "HairSalonId",
                principalTable: "HairSalons",
                principalColumn: "HairSalonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairSalonHairDressers_ApplicationUsers_HairDresserId",
                table: "HairSalonHairDressers");

            migrationBuilder.DropForeignKey(
                name: "FK_HairSalonHairDressers_HairSalons_HairSalonId",
                table: "HairSalonHairDressers");

            migrationBuilder.RenameTable(
                name: "HairSalonHairDressers",
                newName: "HairSalonHairDresser");

            migrationBuilder.RenameIndex(
                name: "IX_HairSalonHairDressers_HairDresserId",
                table: "HairSalonHairDresser",
                newName: "IX_HairSalonHairDresser_HairDresserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HairSalonHairDresser_ApplicationUsers_HairDresserId",
                table: "HairSalonHairDresser",
                column: "HairDresserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HairSalonHairDresser_HairSalons_HairSalonId",
                table: "HairSalonHairDresser",
                column: "HairSalonId",
                principalTable: "HairSalons",
                principalColumn: "HairSalonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
