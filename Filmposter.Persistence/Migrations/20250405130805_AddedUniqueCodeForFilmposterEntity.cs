using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmposter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueCodeForFilmposterEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "FilmPosters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "FilmPosters");
        }
    }
}
