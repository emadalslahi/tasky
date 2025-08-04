using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tasks");
            
            migrationBuilder.DropTable(
                name: "tasks",
                schema: "tasks");

            migrationBuilder.CreateTable(
                name: "tasks",
                schema: "tasks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priority = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: true),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updated_by_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_by_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    assigned_to_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tasks", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks",
                schema: "tasks");
        }
    }
}
