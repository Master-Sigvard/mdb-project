using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mdb_project.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Film");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Year",
                table: "Film",
                type: "datetime2",
                nullable: true);
        }
    }
}
