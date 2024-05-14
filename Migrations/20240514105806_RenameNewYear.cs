using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mdb_project.Migrations
{
    /// <inheritdoc />
    public partial class RenameNewYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year2",
                table: "Film",
                newName: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Film",
                newName: "Year2");
        }
    }
}
