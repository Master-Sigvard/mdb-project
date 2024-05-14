using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mdb_project.Migrations
{
    /// <inheritdoc />
    public partial class newYearField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year2",
                table: "Film",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year2",
                table: "Film");
        }
    }
}
