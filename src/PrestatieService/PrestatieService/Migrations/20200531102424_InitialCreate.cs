using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestatieService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestaties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OefeningId = table.Column<Guid>(nullable: false),
                    KlantId = table.Column<Guid>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Gewicht = table.Column<double>(nullable: true),
                    Herhalingen = table.Column<double>(nullable: false),
                    Opmerking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestaties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestaties");
        }
    }
}
