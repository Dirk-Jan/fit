using Microsoft.EntityFrameworkCore.Migrations;

namespace BFF.Migrations
{
    public partial class OefeningZwaarteAddedToPrestatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Herhalingen",
                table: "Prestaties",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "OefeningZwaarte",
                table: "Prestaties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Prestaties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OefeningZwaarte",
                table: "Prestaties");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Prestaties");

            migrationBuilder.AlterColumn<double>(
                name: "Herhalingen",
                table: "Prestaties",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
