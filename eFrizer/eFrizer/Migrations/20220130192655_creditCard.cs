using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class creditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cvvCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditCardId);
                    table.ForeignKey(
                        name: "FK_CreditCards_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditCards_ApplicationUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_ApplicationUserId",
                table: "CreditCards",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_ClientId",
                table: "CreditCards",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");
        }
    }
}
