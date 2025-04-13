using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmposter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedDesignTariffEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesignTariff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    StaticTariff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoTypeTariff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignTariff", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignTariff");
        }
    }
}
