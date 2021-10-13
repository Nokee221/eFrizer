using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class RemoveHairSalonCityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HairSalonCities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HairSalonCities",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_city", x => new { x.HairSalonId, x.CityId });
                    table.ForeignKey(
                        name: "FK_HairSalonCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairSalonCities_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonCities_CityId",
                table: "HairSalonCities",
                column: "CityId");
        }
    }
}
