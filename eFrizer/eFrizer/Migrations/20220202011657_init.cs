using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "HairSalonTypes",
                columns: table => new
                {
                    HairSalonTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairSalonTypes", x => x.HairSalonTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "HairSalons",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairSalons", x => x.HairSalonId);
                    table.ForeignKey(
                        name: "FK_HairSalons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairSalonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.ApplicationUserId);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HairSalonHairSalonTypes",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    HairSalonTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_hairsalontype", x => new { x.HairSalonId, x.HairSalonTypeId });
                    table.ForeignKey(
                        name: "FK_HairSalonHairSalonTypes_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairSalonHairSalonTypes_HairSalonTypes_HairSalonTypeId",
                        column: x => x.HairSalonTypeId,
                        principalTable: "HairSalonTypes",
                        principalColumn: "HairSalonTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HairSalonPictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    HairSalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_picture", x => new { x.HairSalonId, x.PictureId });
                    table.ForeignKey(
                        name: "FK_HairSalonPictures_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairSalonPictures_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "PictureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HairSalonServices",
                columns: table => new
                {
                    HairSalonServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    TimeMin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairSalonServices", x => x.HairSalonServiceId);
                    table.ForeignKey(
                        name: "FK_HairSalonServices_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairSalonServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRoles",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationuser_role", x => new { x.ApplicationUserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRoles_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HairSalonManagers",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_manager", x => new { x.HairSalonId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_HairSalonManagers_ApplicationUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairSalonManagers_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StarRating = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_hairSalon", x => new { x.ClientId, x.HairSalonId });
                    table.ForeignKey(
                        name: "FK_Reviews_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_ApplicationUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.NoAction);
                });

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
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextReviews_HairSalons_HairSalonId",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalons",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HairSalonServiceLoyaltyBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairSalonServiceId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ActivatesOn = table.Column<int>(type: "int", nullable: false),
                    ExpiresIn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairSalonServiceLoyaltyBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HairSalonServiceLoyaltyBonuses_HairSalonServices_HairSalonServiceId",
                        column: x => x.HairSalonServiceId,
                        principalTable: "HairSalonServices",
                        principalColumn: "HairSalonServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HairSalonServicePictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    HairSalonServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalonservice_picture", x => new { x.HairSalonServiceId, x.PictureId });
                    table.ForeignKey(
                        name: "FK_HairSalonServicePictures_HairSalonServices_HairSalonServiceId",
                        column: x => x.HairSalonServiceId,
                        principalTable: "HairSalonServices",
                        principalColumn: "HairSalonServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairSalonServicePictures_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "PictureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairDresserId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    HairSalonServiceId = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ApplicationUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_ApplicationUsers_HairDresserId",
                        column: x => x.HairDresserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_HairSalonServices_HairSalonServiceId",
                        column: x => x.HairSalonServiceId,
                        principalTable: "HairSalonServices",
                        principalColumn: "HairSalonServiceId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyBonusUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairSalonServiceLoyaltyBonusId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyBonusUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoyaltyBonusUsers_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoyaltyBonusUsers_ApplicationUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoyaltyBonusUsers_HairSalonServiceLoyaltyBonuses_HairSalonServiceLoyaltyBonusId",
                        column: x => x.HairSalonServiceLoyaltyBonusId,
                        principalTable: "HairSalonServiceLoyaltyBonuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_RoleId",
                table: "ApplicationUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_HairSalonId",
                table: "ApplicationUsers",
                column: "HairSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_ApplicationUserId",
                table: "CreditCards",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_ClientId",
                table: "CreditCards",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonHairSalonTypes_HairSalonTypeId",
                table: "HairSalonHairSalonTypes",
                column: "HairSalonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonManagers_ManagerId",
                table: "HairSalonManagers",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonPictures_PictureId",
                table: "HairSalonPictures",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalons_CityId",
                table: "HairSalons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonServiceLoyaltyBonuses_HairSalonServiceId",
                table: "HairSalonServiceLoyaltyBonuses",
                column: "HairSalonServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonServicePictures_PictureId",
                table: "HairSalonServicePictures",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonServices_HairSalonId",
                table: "HairSalonServices",
                column: "HairSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalonServices_ServiceId",
                table: "HairSalonServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyBonusUsers_ApplicationUserId",
                table: "LoyaltyBonusUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyBonusUsers_ClientId",
                table: "LoyaltyBonusUsers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyBonusUsers_HairSalonServiceLoyaltyBonusId",
                table: "LoyaltyBonusUsers",
                column: "HairSalonServiceLoyaltyBonusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HairDresserId",
                table: "Reservations",
                column: "HairDresserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HairSalonServiceId",
                table: "Reservations",
                column: "HairSalonServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HairSalonId",
                table: "Reviews",
                column: "HairSalonId");

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
                name: "ApplicationUserRoles");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "HairSalonHairSalonTypes");

            migrationBuilder.DropTable(
                name: "HairSalonManagers");

            migrationBuilder.DropTable(
                name: "HairSalonPictures");

            migrationBuilder.DropTable(
                name: "HairSalonServicePictures");

            migrationBuilder.DropTable(
                name: "LoyaltyBonusUsers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TextReviews");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "HairSalonTypes");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "HairSalonServiceLoyaltyBonuses");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "HairSalonServices");

            migrationBuilder.DropTable(
                name: "HairSalons");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
