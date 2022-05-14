using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronPython.Migrator.Authorization.Migrations
{
    public partial class CreateUserTableAndAuthorizationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "authorization");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "authorization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true, defaultValueSql: "md5(random()::text)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "authorization");
        }
    }
}
