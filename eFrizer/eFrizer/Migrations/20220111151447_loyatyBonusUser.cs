using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class loyatyBonusUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoyaltyBonusUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoyaltyBonusId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    hairSalonServiceLoyaltyBonusId = table.Column<int>(type: "int", nullable: true),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyBonusUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoyaltyBonusUser_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoyaltyBonusUser_ApplicationUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoyaltyBonusUser_HairSalonServiceLoyaltyBonuses_hairSalonServiceLoyaltyBonusId",
                        column: x => x.hairSalonServiceLoyaltyBonusId,
                        principalTable: "HairSalonServiceLoyaltyBonuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyBonusUser_ApplicationUserId",
                table: "LoyaltyBonusUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyBonusUser_ClientId",
                table: "LoyaltyBonusUser",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyBonusUser_hairSalonServiceLoyaltyBonusId",
                table: "LoyaltyBonusUser",
                column: "hairSalonServiceLoyaltyBonusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoyaltyBonusUser");
        }
    }
}
