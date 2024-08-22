using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Leavecoverpersonupdatemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                 name: "FK_leaves_employees_CoverPersonId",
                 table: "leaves");

            // Drop the index if it exists (optional)
            migrationBuilder.DropIndex(
                name: "IX_leaves_CoverPersonId",
                table: "leaves");

            // Alter the CoverPersonStatus column to be nullable
            migrationBuilder.AlterColumn<int>(
                name: "CoverPersonStatus",
                table: "leaves",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            // Create the index on CoverPersonId
            migrationBuilder.CreateIndex(
                name: "IX_leaves_CoverPersonId",
                table: "leaves",
                column: "CoverPersonId");

            // Recreate the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_leaves_employees_CoverPersonId",
                table: "leaves",
                column: "CoverPersonId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaves_employees_CoverPersonId",
                table: "leaves");

            // Drop the index if it exists
            migrationBuilder.DropIndex(
                name: "IX_leaves_CoverPersonId",
                table: "leaves");

            // Revert the CoverPersonStatus column to non-nullable
            migrationBuilder.AlterColumn<int>(
                name: "CoverPersonStatus",
                table: "leaves",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
    }

