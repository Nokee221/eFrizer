using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class manager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerApplicationUserId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manager_Description",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HairSalonManagers",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_manager", x => new { x.HairSalonId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_HairSalonManagers_ApplicationUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairSalonManagers_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ManagerApplicationUserId",
                table: "Reservations",
                column: "ManagerApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonManagers_ManagerId",
                table: "HairSalonManagers",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ApplicationUsers_ManagerApplicationUserId",
                table: "Reservations",
                column: "ManagerApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ApplicationUsers_ManagerApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "HairSalonManagers");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ManagerApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ManagerApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Manager_Description",
                table: "ApplicationUsers");
        }
    }
}
