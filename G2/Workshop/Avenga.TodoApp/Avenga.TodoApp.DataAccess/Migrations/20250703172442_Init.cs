using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Avenga.TodoApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Todos_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Home" },
                    { 3, "Exercise" },
                    { 4, "Shopping" },
                    { 5, "Hobbie" },
                    { 6, "FreeTime" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CategoryId", "Description", "DueDate", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, "Finish project presentation", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, 2, "Clean the kitchen", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, 3, "Morning jog in the park", new DateTime(2025, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 4, 4, "Buy groceries for the week", new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 5, 6, "Read a chapter from a novel", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_CategoryId",
                table: "Todos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_StatusId",
                table: "Todos",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
