using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BFF.Migrations
{
    public partial class AddedKlantIdToPrestatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KlantId",
                table: "Prestaties",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Prestaties");
        }
    }
}
