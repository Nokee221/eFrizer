using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class AddHairSalonHairDresserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HairSalonHairDresser",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    HairDresserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_hairdresser", x => new { x.HairSalonId, x.HairDresserId });
                    table.ForeignKey(
                        name: "FK_HairSalonHairDresser_HairDressers_HairDresserId",
                        column: x => x.HairDresserId,
                        principalTable: "HairDressers",
                        principalColumn: "HairDresserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairSalonHairDresser_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonHairDresser_HairDresserId",
                table: "HairSalonHairDresser",
                column: "HairDresserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HairSalonHairDresser");
        }
    }
}
