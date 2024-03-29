using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowTagApp.Core.SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastActivityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasSynonyms = table.Column<bool>(type: "bit", nullable: false),
                    IsModeratorOnly = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PercentageOfTags = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
