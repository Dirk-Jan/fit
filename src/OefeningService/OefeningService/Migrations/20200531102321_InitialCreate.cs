using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OefeningService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oefeningen",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oefeningen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oefeningen");
        }
    }
}
