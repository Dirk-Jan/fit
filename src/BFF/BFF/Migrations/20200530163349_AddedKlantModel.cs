using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BFF.Migrations
{
    public partial class AddedKlantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klanten");
        }
    }
}
