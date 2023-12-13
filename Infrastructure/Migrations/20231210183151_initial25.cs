using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "TaskManagement",
                table: "SprintTasks");

            migrationBuilder.AddColumn<string>(
                name: "SprintDescription",
                schema: "TaskManagement",
                table: "Sprints",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaskDuration",
                schema: "TaskManagement",
                table: "SprintTasks",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "ProjectDescription",
                schema: "TaskManagement",
                table: "Projects",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SprintDescription",
                schema: "TaskManagement",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "ProjectDescription",
                schema: "TaskManagement",
                table: "Projects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaskDuration",
                schema: "TaskManagement",
                table: "SprintTasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                schema: "TaskManagement",
                table: "SprintTasks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
