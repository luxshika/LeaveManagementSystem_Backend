using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Leavecoverpersonupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CoverPersonStatus",
                table: "leaves",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_leaves_CoverPersonId",
                table: "leaves",
                column: "CoverPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaves_employees_CoverPersonId",
                table: "leaves",
                column: "CoverPersonId",
                principalTable: "employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaves_employees_CoverPersonId",
                table: "leaves");

            migrationBuilder.DropIndex(
                name: "IX_leaves_CoverPersonId",
                table: "leaves");

            migrationBuilder.AlterColumn<bool>(
                name: "CoverPersonStatus",
                table: "leaves",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
