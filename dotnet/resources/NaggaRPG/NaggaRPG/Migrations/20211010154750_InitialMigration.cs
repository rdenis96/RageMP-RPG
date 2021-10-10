using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NaggaRPG.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Username = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastActiveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsLogged = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Warns = table.Column<int>(type: "int", nullable: false),
                    Mute_IsMuted = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Mute_ExpirationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Mute_Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlayerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    RespectPoints = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastActiveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<long>(type: "bigint", nullable: false),
                    BankMoney = table.Column<long>(type: "bigint", nullable: false),
                    Position_X = table.Column<float>(type: "float", nullable: true),
                    Position_Y = table.Column<float>(type: "float", nullable: true),
                    Position_Z = table.Column<float>(type: "float", nullable: true),
                    Rotation_X = table.Column<float>(type: "float", nullable: true),
                    Rotation_Y = table.Column<float>(type: "float", nullable: true),
                    Rotation_Z = table.Column<float>(type: "float", nullable: true),
                    IdCard_RealName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCard_BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdCard_Sex = table.Column<int>(type: "int", nullable: true),
                    Admin_AdminLevel = table.Column<int>(type: "int", nullable: true),
                    Admin_ChatColor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mute_IsMuted = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Mute_ExpirationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Mute_Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Licenses = table.Column<int>(type: "int", nullable: false),
                    TimePlayed = table.Column<double>(type: "double", nullable: false),
                    FactionInfoId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerInfos_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerInfos_factions_FactionInfoId",
                        column: x => x.FactionInfoId,
                        principalTable: "factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_Username",
                table: "accounts",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInfos_AccountId",
                table: "PlayerInfos",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInfos_FactionInfoId",
                table: "PlayerInfos",
                column: "FactionInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerInfos");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "factions");
        }
    }
}
