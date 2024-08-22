using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AllocatedLeavemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "allocatedLeaves",
                columns: table => new
                {
                    LeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    allocated = table.Column<double>(type: "float", nullable: false),
                    taken = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allocatedLeaves", x => x.LeaveId);
                    table.ForeignKey(
                        name: "FK_allocatedLeaves_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_allocatedLeaves_leavetypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leavetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_allocatedLeaves_EmployeeId",
                table: "allocatedLeaves",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_allocatedLeaves_LeaveTypeId",
                table: "allocatedLeaves",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allocatedLeaves");
        }
    }
}
