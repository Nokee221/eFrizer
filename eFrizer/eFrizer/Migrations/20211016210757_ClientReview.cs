using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class ClientReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Reviews",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews",
                newName: "IX_Reviews_ClientId");

            migrationBuilder.AddColumn<int>(
                name: "HairDresserApplicationUserId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerApplicationUserId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HairDresserApplicationUserId",
                table: "Reviews",
                column: "HairDresserApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ManagerApplicationUserId",
                table: "Reviews",
                column: "ManagerApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUsers_ClientId",
                table: "Reviews",
                column: "ClientId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUsers_HairDresserApplicationUserId",
                table: "Reviews",
                column: "HairDresserApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUsers_ManagerApplicationUserId",
                table: "Reviews",
                column: "ManagerApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_ClientId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_HairDresserApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_ManagerApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_HairDresserApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ManagerApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "HairDresserApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ManagerApplicationUserId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Reviews",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ClientId",
                table: "Reviews",
                newName: "IX_Reviews_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUsers_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
