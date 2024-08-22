using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem_Backend.Migrations
{
    /// <inheritdoc />
    public partial class LeaveUpdatemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_leaves_EmployeeId",
                table: "leaves",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaves_employees_EmployeeId",
                table: "leaves",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaves_employees_EmployeeId",
                table: "leaves");

            migrationBuilder.DropIndex(
                name: "IX_leaves_EmployeeId",
                table: "leaves");
        }
    }
}
