﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem_Backend.Migrations
{
    /// <inheritdoc />
    public partial class TeamMember3migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeamMembers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TeamMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}