using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmposter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedShortFeatureProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "ShortFeature",
                table: "FilmPosters",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ShortFeature",
                table: "FilmPosters",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
