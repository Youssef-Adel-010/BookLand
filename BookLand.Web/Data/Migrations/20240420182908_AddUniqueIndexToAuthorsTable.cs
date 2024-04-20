using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLand.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToAuthorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name",
                table: "Authors",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_Name",
                table: "Authors");
        }
    }
}
