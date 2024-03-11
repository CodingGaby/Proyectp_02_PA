using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyectp_02_PA.Migrations
{
    /// <inheritdoc />
    public partial class Secdn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FistName",
                table: "Users",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "FistName");
        }
    }
}
