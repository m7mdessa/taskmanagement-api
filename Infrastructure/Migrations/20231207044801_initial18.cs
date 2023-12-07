using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Roles_RoleId",
                schema: "TaskManagement",
                table: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Developers_RoleId",
                schema: "TaskManagement",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "TaskManagement",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "TaskManagement",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "TaskManagement",
                table: "Developers");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "TaskManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    DeveloperId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "TaskManagement",
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLogins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "TaskManagement",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_DeveloperId",
                schema: "TaskManagement",
                table: "UserLogins",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_RoleId",
                schema: "TaskManagement",
                table: "UserLogins",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "TaskManagement");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "TaskManagement",
                table: "Developers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                schema: "TaskManagement",
                table: "Developers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "TaskManagement",
                table: "Developers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Developers_RoleId",
                schema: "TaskManagement",
                table: "Developers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Roles_RoleId",
                schema: "TaskManagement",
                table: "Developers",
                column: "RoleId",
                principalSchema: "TaskManagement",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
