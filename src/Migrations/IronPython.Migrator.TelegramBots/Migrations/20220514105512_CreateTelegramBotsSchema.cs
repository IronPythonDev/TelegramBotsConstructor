using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronPython.Migrator.TelegramBots.Migrations
{
    public partial class CreateTelegramBotsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "telegramBots");

            migrationBuilder.CreateTable(
                name: "TelegramBots",
                schema: "telegramBots",
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
                schema: "telegramBots",
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
                        principalSchema: "telegramBots",
                        principalTable: "TelegramBots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelegramBotsOwners",
                schema: "telegramBots",
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
                        principalSchema: "telegramBots",
                        principalTable: "TelegramBots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelegramBotsActionTasks",
                schema: "telegramBots",
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
                        principalSchema: "telegramBots",
                        principalTable: "TelegramBotsActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelegramBotsActionTriggers",
                schema: "telegramBots",
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
                        principalSchema: "telegramBots",
                        principalTable: "TelegramBotsActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelegramBotsActions_TelegramBotId",
                schema: "telegramBots",
                table: "TelegramBotsActions",
                column: "TelegramBotId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramBotsActionTasks_TelegramBotActionId",
                schema: "telegramBots",
                table: "TelegramBotsActionTasks",
                column: "TelegramBotActionId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramBotsActionTriggers_TelegramBotActionId",
                schema: "telegramBots",
                table: "TelegramBotsActionTriggers",
                column: "TelegramBotActionId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramBotsOwners_TelegramBotId",
                schema: "telegramBots",
                table: "TelegramBotsOwners",
                column: "TelegramBotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelegramBotsActionTasks",
                schema: "telegramBots");

            migrationBuilder.DropTable(
                name: "TelegramBotsActionTriggers",
                schema: "telegramBots");

            migrationBuilder.DropTable(
                name: "TelegramBotsOwners",
                schema: "telegramBots");

            migrationBuilder.DropTable(
                name: "TelegramBotsActions",
                schema: "telegramBots");

            migrationBuilder.DropTable(
                name: "TelegramBots",
                schema: "telegramBots");
        }
    }
}
