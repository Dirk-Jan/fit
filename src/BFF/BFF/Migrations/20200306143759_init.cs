using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BFF.Migrations
{
    public partial class init : Migration
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

            migrationBuilder.CreateTable(
                name: "Prestaties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OefeningId = table.Column<Guid>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Gewicht = table.Column<double>(nullable: false),
                    Set1 = table.Column<int>(nullable: false),
                    Set2 = table.Column<int>(nullable: false),
                    Set3 = table.Column<int>(nullable: false),
                    Opmerking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestaties_Oefeningen_OefeningId",
                        column: x => x.OefeningId,
                        principalTable: "Oefeningen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestaties_OefeningId",
                table: "Prestaties",
                column: "OefeningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestaties");

            migrationBuilder.DropTable(
                name: "Oefeningen");
        }
    }
}
