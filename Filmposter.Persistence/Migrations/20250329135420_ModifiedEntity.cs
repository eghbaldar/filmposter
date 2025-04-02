using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmposter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NationFilmPosters",
                table: "NationFilmPosters");

            migrationBuilder.RenameTable(
                name: "NationFilmPosters",
                newName: "FilmPosters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmPosters",
                table: "FilmPosters",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmPosters",
                table: "FilmPosters");

            migrationBuilder.RenameTable(
                name: "FilmPosters",
                newName: "NationFilmPosters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NationFilmPosters",
                table: "NationFilmPosters",
                column: "Id");
        }
    }
}
