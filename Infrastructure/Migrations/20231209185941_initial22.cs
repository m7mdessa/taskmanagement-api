using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TaskDuration",
                schema: "TaskManagement",
                table: "SprintTasks",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TaskDuration",
                schema: "TaskManagement",
                table: "SprintTasks",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
