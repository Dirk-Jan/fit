using Microsoft.EntityFrameworkCore.Migrations;

namespace BFF.Migrations
{
    public partial class PrestatieVeranderd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Prestaties");

            migrationBuilder.AddColumn<double>(
                name: "Herhalingen",
                table: "Prestaties",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Herhalingen",
                table: "Prestaties");

            migrationBuilder.AddColumn<double>(
                name: "Reps",
                table: "Prestaties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
