using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kieszonstwory.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pokonane",
                table: "Trenerzy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Złapane",
                table: "Trenerzy",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pokonane",
                table: "Trenerzy");

            migrationBuilder.DropColumn(
                name: "Złapane",
                table: "Trenerzy");
        }
    }
}
