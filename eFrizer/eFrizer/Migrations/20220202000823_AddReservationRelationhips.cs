using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class AddReservationRelationhips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_HairSalonServices_HairSalonServiceId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_HairSalonServices_HairSalonServiceId",
                table: "Reservations",
                column: "HairSalonServiceId",
                principalTable: "HairSalonServices",
                principalColumn: "HairSalonServiceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_HairSalonServices_HairSalonServiceId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_HairSalonServices_HairSalonServiceId",
                table: "Reservations",
                column: "HairSalonServiceId",
                principalTable: "HairSalonServices",
                principalColumn: "HairSalonServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
