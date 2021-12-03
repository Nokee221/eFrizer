using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class RemoveCompositePrimaryKeyFromHairSalonService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairSalonServiceLoyaltyBonuses_HairSalonServices_ServiceHairSalonId_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hairsalon_service",
                table: "HairSalonServices");

            migrationBuilder.DropIndex(
                name: "IX_HairSalonServiceLoyaltyBonuses_ServiceHairSalonId_ServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropColumn(
                name: "ServiceHairSalonId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HairSalonServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HairSalonServices",
                table: "HairSalonServices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonServices_HairSalonId",
                table: "HairSalonServices",
                column: "HairSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonServiceLoyaltyBonuses_HairSalonServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                column: "HairSalonServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HairSalonServiceLoyaltyBonuses_HairSalonServices_HairSalonServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                column: "HairSalonServiceId",
                principalTable: "HairSalonServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairSalonServiceLoyaltyBonuses_HairSalonServices_HairSalonServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HairSalonServices",
                table: "HairSalonServices");

            migrationBuilder.DropIndex(
                name: "IX_HairSalonServices_HairSalonId",
                table: "HairSalonServices");

            migrationBuilder.DropIndex(
                name: "IX_HairSalonServiceLoyaltyBonuses_HairSalonServiceId",
                table: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HairSalonServices");

            migrationBuilder.AddColumn<int>(
                name: "ServiceHairSalonId",
                table: "HairSalonServiceLoyaltyBonuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_hairsalon_service",
                table: "HairSalonServices",
                columns: new[] { "HairSalonId", "ServiceId" });

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
    }
}
