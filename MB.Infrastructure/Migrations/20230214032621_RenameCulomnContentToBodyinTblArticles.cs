using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameCulomnContentToBodyinTblArticles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Articles",
                newName: "Body");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Articles",
                newName: "Content");
        }
    }
}
