using Microsoft.EntityFrameworkCore.Migrations;

namespace BFF.Migrations
{
    public partial class OefeningSpiergroepToegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Spiergroep",
                table: "Oefeningen",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spiergroep",
                table: "Oefeningen");
        }
    }
}
