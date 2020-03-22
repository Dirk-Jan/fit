using Microsoft.EntityFrameworkCore.Migrations;

namespace BFF.Migrations
{
    public partial class PrestatieVeranderd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Set1",
                table: "Prestaties");

            migrationBuilder.DropColumn(
                name: "Set2",
                table: "Prestaties");

            migrationBuilder.DropColumn(
                name: "Set3",
                table: "Prestaties");

            migrationBuilder.AddColumn<double>(
                name: "Reps",
                table: "Prestaties",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Prestaties");

            migrationBuilder.AddColumn<int>(
                name: "Set1",
                table: "Prestaties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Set2",
                table: "Prestaties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Set3",
                table: "Prestaties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
