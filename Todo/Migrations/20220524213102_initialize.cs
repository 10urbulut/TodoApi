using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyTodos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TodoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoTag = table.Column<int>(type: "int", nullable: false),
                    TodoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTodos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyTodos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TodoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoTag = table.Column<int>(type: "int", nullable: false),
                    TodoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyTodos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyTodos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TodoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoTag = table.Column<int>(type: "int", nullable: false),
                    TodoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyTodos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyTodos");

            migrationBuilder.DropTable(
                name: "MonthlyTodos");

            migrationBuilder.DropTable(
                name: "WeeklyTodos");
        }
    }
}
