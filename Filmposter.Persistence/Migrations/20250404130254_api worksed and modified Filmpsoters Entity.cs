using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmposter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class apiworksedandmodifiedFilmpsotersEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "FilmPosters");

            migrationBuilder.AddColumn<byte>(
                name: "Style",
                table: "FilmPosters",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FilmPosters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte>(
                name: "Validation",
                table: "FilmPosters",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_FilmPosters_UserId",
                table: "FilmPosters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmPosters_Users_UserId",
                table: "FilmPosters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmPosters_Users_UserId",
                table: "FilmPosters");

            migrationBuilder.DropIndex(
                name: "IX_FilmPosters_UserId",
                table: "FilmPosters");

            migrationBuilder.DropColumn(
                name: "Style",
                table: "FilmPosters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FilmPosters");

            migrationBuilder.DropColumn(
                name: "Validation",
                table: "FilmPosters");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "FilmPosters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
