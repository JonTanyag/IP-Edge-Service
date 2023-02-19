using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPEdge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Employees",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeID");
        }
    }
}
