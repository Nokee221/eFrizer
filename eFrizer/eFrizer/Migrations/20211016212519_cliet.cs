using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class cliet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ApplicationUsers_ManagerApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_HairDresserApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_ManagerApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_HairDresserApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "HairDresserApplicationUserId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ManagerApplicationUserId",
                table: "Reviews",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ManagerApplicationUserId",
                table: "Reviews",
                newName: "IX_Reviews_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ManagerApplicationUserId",
                table: "Reservations",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ManagerApplicationUserId",
                table: "Reservations",
                newName: "IX_Reservations_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ApplicationUsers_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUsers_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ApplicationUsers_ApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Reviews",
                newName: "ManagerApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews",
                newName: "IX_Reviews_ManagerApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Reservations",
                newName: "ManagerApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ApplicationUserId",
                table: "Reservations",
                newName: "IX_Reservations_ManagerApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "HairDresserApplicationUserId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HairDresserApplicationUserId",
                table: "Reviews",
                column: "HairDresserApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ApplicationUsers_ManagerApplicationUserId",
                table: "Reservations",
                column: "ManagerApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

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
    }
}
