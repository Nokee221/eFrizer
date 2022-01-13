using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class ReplaceServiceWithHairSalonServiceInReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HairSalonServiceId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HairSalonServiceId",
                table: "Reservations",
                column: "HairSalonServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_HairSalonServices_HairSalonServiceId",
                table: "Reservations",
                column: "HairSalonServiceId",
                principalTable: "HairSalonServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_HairSalonServices_HairSalonServiceId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_HairSalonServiceId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "HairSalonServiceId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
