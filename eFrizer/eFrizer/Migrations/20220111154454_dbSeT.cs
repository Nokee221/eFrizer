using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class dbSeT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoyaltyBonusUser_ApplicationUsers_ApplicationUserId",
                table: "LoyaltyBonusUser");

            migrationBuilder.DropForeignKey(
                name: "FK_LoyaltyBonusUser_ApplicationUsers_ClientId",
                table: "LoyaltyBonusUser");

            migrationBuilder.DropForeignKey(
                name: "FK_LoyaltyBonusUser_HairSalonServiceLoyaltyBonuses_hairSalonServiceLoyaltyBonusId",
                table: "LoyaltyBonusUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoyaltyBonusUser",
                table: "LoyaltyBonusUser");

            migrationBuilder.RenameTable(
                name: "LoyaltyBonusUser",
                newName: "LoyaltyBonusUsers");

            migrationBuilder.RenameIndex(
                name: "IX_LoyaltyBonusUser_hairSalonServiceLoyaltyBonusId",
                table: "LoyaltyBonusUsers",
                newName: "IX_LoyaltyBonusUsers_hairSalonServiceLoyaltyBonusId");

            migrationBuilder.RenameIndex(
                name: "IX_LoyaltyBonusUser_ClientId",
                table: "LoyaltyBonusUsers",
                newName: "IX_LoyaltyBonusUsers_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LoyaltyBonusUser_ApplicationUserId",
                table: "LoyaltyBonusUsers",
                newName: "IX_LoyaltyBonusUsers_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoyaltyBonusUsers",
                table: "LoyaltyBonusUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoyaltyBonusUsers_ApplicationUsers_ApplicationUserId",
                table: "LoyaltyBonusUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoyaltyBonusUsers_ApplicationUsers_ClientId",
                table: "LoyaltyBonusUsers",
                column: "ClientId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoyaltyBonusUsers_HairSalonServiceLoyaltyBonuses_hairSalonServiceLoyaltyBonusId",
                table: "LoyaltyBonusUsers",
                column: "hairSalonServiceLoyaltyBonusId",
                principalTable: "HairSalonServiceLoyaltyBonuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoyaltyBonusUsers_ApplicationUsers_ApplicationUserId",
                table: "LoyaltyBonusUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LoyaltyBonusUsers_ApplicationUsers_ClientId",
                table: "LoyaltyBonusUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LoyaltyBonusUsers_HairSalonServiceLoyaltyBonuses_hairSalonServiceLoyaltyBonusId",
                table: "LoyaltyBonusUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoyaltyBonusUsers",
                table: "LoyaltyBonusUsers");

            migrationBuilder.RenameTable(
                name: "LoyaltyBonusUsers",
                newName: "LoyaltyBonusUser");

            migrationBuilder.RenameIndex(
                name: "IX_LoyaltyBonusUsers_hairSalonServiceLoyaltyBonusId",
                table: "LoyaltyBonusUser",
                newName: "IX_LoyaltyBonusUser_hairSalonServiceLoyaltyBonusId");

            migrationBuilder.RenameIndex(
                name: "IX_LoyaltyBonusUsers_ClientId",
                table: "LoyaltyBonusUser",
                newName: "IX_LoyaltyBonusUser_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LoyaltyBonusUsers_ApplicationUserId",
                table: "LoyaltyBonusUser",
                newName: "IX_LoyaltyBonusUser_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoyaltyBonusUser",
                table: "LoyaltyBonusUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoyaltyBonusUser_ApplicationUsers_ApplicationUserId",
                table: "LoyaltyBonusUser",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoyaltyBonusUser_ApplicationUsers_ClientId",
                table: "LoyaltyBonusUser",
                column: "ClientId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoyaltyBonusUser_HairSalonServiceLoyaltyBonuses_hairSalonServiceLoyaltyBonusId",
                table: "LoyaltyBonusUser",
                column: "hairSalonServiceLoyaltyBonusId",
                principalTable: "HairSalonServiceLoyaltyBonuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
