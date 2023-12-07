using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "Sprints",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "SprintTasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "Roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "Developers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "SprintTasks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TaskManagement",
                table: "Developers");
        }
    }
}
