using Microsoft.EntityFrameworkCore.Migrations;
using System.Text.Json;

#nullable disable

namespace IronPython.Migrator.TelegramBots.Migrations
{
    public partial class CreateTelegramBotsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelegramBots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, defaultValue: "Unknown Name!")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramBots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelegramBotsActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: false, defaultValue: "New Action!"),
                    TelegramBotId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramBotsActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelegramBotsActions_TelegramBots_TelegramBotId",
                        column: x => x.TelegramBotId,
                        principalTable: "TelegramBots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelegramBotsOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    TelegramBotId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramBotsOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelegramBotsOwners_TelegramBots_TelegramBotId",
                        column: x => x.TelegramBotId,
                        principalTable: "TelegramBots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelegramBotsActionTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Type = table.Column<string>(type: "text", nullable: false, defaultValue: "Unknown"),
                    Params = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    TelegramBotActionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramBotsActionTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelegramBotsActionTasks_TelegramBotsActions_TelegramBotActi~",
                        column: x => x.TelegramBotActionId,
                        principalTable: "TelegramBotsActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelegramBotsActionTriggers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Type = table.Column<string>(type: "text", nullable: false, defaultValue: "Unknown"),
                    Params = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    TelegramBotActionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramBotsActionTriggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelegramBotsActionTriggers_TelegramBotsActions_TelegramBotA~",
                        column: x => x.TelegramBotActionId,
                        principalTable: "TelegramBotsActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelegramBotsActions_TelegramBotId",
                table: "TelegramBotsActions",
                column: "TelegramBotId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramBotsActionTasks_TelegramBotActionId",
                table: "TelegramBotsActionTasks",
                column: "TelegramBotActionId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramBotsActionTriggers_TelegramBotActionId",
                table: "TelegramBotsActionTriggers",
                column: "TelegramBotActionId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramBotsOwners_TelegramBotId",
                table: "TelegramBotsOwners",
                column: "TelegramBotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelegramBotsActionTasks");

            migrationBuilder.DropTable(
                name: "TelegramBotsActionTriggers");

            migrationBuilder.DropTable(
                name: "TelegramBotsOwners");

            migrationBuilder.DropTable(
                name: "TelegramBotsActions");

            migrationBuilder.DropTable(
                name: "TelegramBots");
        }
    }
}
