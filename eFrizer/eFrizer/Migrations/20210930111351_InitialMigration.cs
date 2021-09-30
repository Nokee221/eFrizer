using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFrizer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.ApplicationUserId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "HairSalon",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairSalon", x => x.HairSalonId);
                });

            migrationBuilder.CreateTable(
                name: "HairSalonType",
                columns: table => new
                {
                    HairSalonTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairSalonType", x => x.HairSalonTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.ServicesId);
                });

            migrationBuilder.CreateTable(
                name: "HairDresser",
                columns: table => new
                {
                    HairDresserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HairSalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairDresser", x => x.HairDresserId);
                    table.ForeignKey(
                        name: "FK_73",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalon",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairSalon_City",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_13", x => new { x.HairSalonId, x.CityId });
                    table.ForeignKey(
                        name: "FK_22",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalon",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_32",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_102",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalon",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_105",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairSalon_HairSalonType",
                columns: table => new
                {
                    HairSalonId = table.Column<int>(type: "int", nullable: false),
                    HairSalonTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_hairsalontype", x => new { x.HairSalonId, x.HairSalonTypeID });
                    table.ForeignKey(
                        name: "FK_111",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalon",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_115",
                        column: x => x.HairSalonTypeID,
                        principalTable: "HairSalonType",
                        principalColumn: "HairSalonTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairSalon_Picture",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    HairSalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_picture", x => new { x.PictureId, x.HairSalonId });
                    table.ForeignKey(
                        name: "FK_48",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "PictureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_56",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalon",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser_Role",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationuser_role", x => new { x.ApplicationUserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_93",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_97",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairSalon_Services",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    HairSalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairsalon_services", x => new { x.ServicesId, x.HairSalonId });
                    table.ForeignKey(
                        name: "FK_63",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "ServicesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_67",
                        column: x => x.HairSalonId,
                        principalTable: "HairSalon",
                        principalColumn: "HairSalonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairDresserId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_81",
                        column: x => x.HairDresserId,
                        principalTable: "HairDresser",
                        principalColumn: "HairDresserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_86",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_Role_RoleId",
                table: "ApplicationUser_Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_HairDresser_HairSalonId",
                table: "HairDresser",
                column: "HairSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalon_City_CityId",
                table: "HairSalon_City",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalon_HairSalonType_HairSalonTypeID",
                table: "HairSalon_HairSalonType",
                column: "HairSalonTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalon_Picture_HairSalonId",
                table: "HairSalon_Picture",
                column: "HairSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSalon_Services_HairSalonId",
                table: "HairSalon_Services",
                column: "HairSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ApplicationUserId",
                table: "Reservation",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_HairDresserId",
                table: "Reservation",
                column: "HairDresserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ApplicationUserId",
                table: "Review",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_HairSalonId",
                table: "Review",
                column: "HairSalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUser_Role");

            migrationBuilder.DropTable(
                name: "HairSalon_City");

            migrationBuilder.DropTable(
                name: "HairSalon_HairSalonType");

            migrationBuilder.DropTable(
                name: "HairSalon_Picture");

            migrationBuilder.DropTable(
                name: "HairSalon_Services");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "HairSalonType");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "HairDresser");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "HairSalon");
        }
    }
}
