using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kieszonstwory.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DzikiStwor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Poziom = table.Column<int>(type: "int", nullable: false),
                    Moc = table.Column<int>(type: "int", nullable: false),
                    BaseMoc = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    BaseHP = table.Column<int>(type: "int", nullable: false),
                    Obrazek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypStworaId = table.Column<int>(type: "int", nullable: false),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DzikiStwor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokalizacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokalizacje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypyStworow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyStworow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trenerzy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Poziom = table.Column<int>(type: "int", nullable: false),
                    Exp = table.Column<int>(type: "int", nullable: false),
                    Złapane = table.Column<int>(type: "int", nullable: false),
                    Pokonane = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trenerzy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trenerzy_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Esencja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(type: "int", nullable: false),
                    TypId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esencja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Esencja_TypyStworow_TypId",
                        column: x => x.TypId,
                        principalTable: "TypyStworow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kieszonstwory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Poziom = table.Column<int>(type: "int", nullable: false),
                    Moc = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    BaseHP = table.Column<int>(type: "int", nullable: false),
                    Obrazek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypStworaId = table.Column<int>(type: "int", nullable: false),
                    TrenerId = table.Column<int>(type: "int", nullable: false),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false),
                    CzyFav = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kieszonstwory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kieszonstwory_Lokalizacje_LokalizacjaId",
                        column: x => x.LokalizacjaId,
                        principalTable: "Lokalizacje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kieszonstwory_Trenerzy_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "Trenerzy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kieszonstwory_TypyStworow_TypStworaId",
                        column: x => x.TypStworaId,
                        principalTable: "TypyStworow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Walka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DzikiStworId = table.Column<int>(type: "int", nullable: false),
                    KieszonstworId = table.Column<int>(type: "int", nullable: false),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false),
                    Komunikat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wynik = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walka_DzikiStwor_DzikiStworId",
                        column: x => x.DzikiStworId,
                        principalTable: "DzikiStwor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walka_Kieszonstwory_KieszonstworId",
                        column: x => x.KieszonstworId,
                        principalTable: "Kieszonstwory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DzikiStwor",
                columns: new[] { "Id", "BaseHP", "BaseMoc", "HP", "LokalizacjaId", "Moc", "Nazwa", "Obrazek", "Poziom", "TypStworaId" },
                values: new object[,]
                {
                    { 1, 50, 4, 50, 1, 4, "Skalniak", "skalniak.png", 1, 2 },
                    { 2, 40, 4, 40, 1, 4, "Ziemok", "ziemok.png", 1, 1 },
                    { 3, 30, 5, 30, 1, 5, "Taktoperz", "taktoperz.png", 1, 3 },
                    { 4, 15, 4, 15, 2, 4, "Szybkonóg", "szybkonog.png", 1, 4 },
                    { 5, 25, 5, 25, 2, 5, "Reed", "reed.png", 1, 4 },
                    { 6, 20, 2, 20, 2, 2, "Głąp", "glap.png", 1, 3 },
                    { 7, 30, 3, 30, 3, 3, "Bober", "bober.png", 1, 5 },
                    { 8, 40, 5, 40, 3, 5, "Płetw", "pletw.png", 1, 5 },
                    { 9, 35, 2, 35, 3, 2, "Krak", "krak.png", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Lokalizacje",
                columns: new[] { "Id", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Góry" },
                    { 2, "Polana" },
                    { 3, "Wybrzeże" }
                });

            migrationBuilder.InsertData(
                table: "TypyStworow",
                columns: new[] { "Id", "Nazwa", "Opis" },
                values: new object[,]
                {
                    { 1, "ziemny", "Żyją w ziemi" },
                    { 2, "skalny", "Są z kamulca" },
                    { 3, "latający", "Latają, chociaż czasami nie" },
                    { 4, "roślinny", "Żyją w roślinach,jedzą rośliny" },
                    { 5, "wodny", "Bul bul bul" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Esencja_TypId",
                table: "Esencja",
                column: "TypId");

            migrationBuilder.CreateIndex(
                name: "IX_Kieszonstwory_LokalizacjaId",
                table: "Kieszonstwory",
                column: "LokalizacjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kieszonstwory_TrenerId",
                table: "Kieszonstwory",
                column: "TrenerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kieszonstwory_TypStworaId",
                table: "Kieszonstwory",
                column: "TypStworaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trenerzy_UserId",
                table: "Trenerzy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Walka_DzikiStworId",
                table: "Walka",
                column: "DzikiStworId");

            migrationBuilder.CreateIndex(
                name: "IX_Walka_KieszonstworId",
                table: "Walka",
                column: "KieszonstworId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Esencja");

            migrationBuilder.DropTable(
                name: "Walka");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DzikiStwor");

            migrationBuilder.DropTable(
                name: "Kieszonstwory");

            migrationBuilder.DropTable(
                name: "Lokalizacje");

            migrationBuilder.DropTable(
                name: "Trenerzy");

            migrationBuilder.DropTable(
                name: "TypyStworow");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
