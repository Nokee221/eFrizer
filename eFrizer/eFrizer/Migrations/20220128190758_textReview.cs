using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class textReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Reviews");

            migrationBuilder.CreateTable(
                name: "TextReviews",
                columns: table => new
                {
                    TextReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextReviews", x => x.TextReviewId);
                    table.ForeignKey(
                        name: "FK_TextReviews_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TextReviews_ApplicationUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId");
                    table.ForeignKey(
                        name: "FK_TextReviews_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextReviews_ApplicationUserId",
                table: "TextReviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TextReviews_ClientId",
                table: "TextReviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TextReviews_HairSalonId",
                table: "TextReviews",
                column: "HairSalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextReviews");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
