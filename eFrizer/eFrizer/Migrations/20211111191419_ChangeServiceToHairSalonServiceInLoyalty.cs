using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class ChangeServiceToHairSalonServiceInLoyalty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairSalonServiceLoyaltyBonuses_Services_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropIndex(
                name: "IX_HairSalonServiceLoyaltyBonuses_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.AddColumn<int>(
                name: "HairSalonServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceHairSalonId",
                table: "HairSalonServiceLoyaltyBonuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonServiceLoyaltyBonuses_ServiceHairSalonId_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                columns: new[] { "ServiceHairSalonId", "ServiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HairSalonServiceLoyaltyBonuses_HairSalonServices_ServiceHairSalonId_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                columns: new[] { "ServiceHairSalonId", "ServiceId" },
                principalTable: "HairSalonServices",
                principalColumns: new[] { "HairSalonId", "ServiceId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairSalonServiceLoyaltyBonuses_HairSalonServices_ServiceHairSalonId_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropIndex(
                name: "IX_HairSalonServiceLoyaltyBonuses_ServiceHairSalonId_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropColumn(
                name: "HairSalonServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropColumn(
                name: "ServiceHairSalonId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonServiceLoyaltyBonuses_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HairSalonServiceLoyaltyBonuses_Services_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
