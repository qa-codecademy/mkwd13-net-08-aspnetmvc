using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Avenga.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_ActiveCourseId",
                        column: x => x.ActiveCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "NumberOfClasses" },
                values: new object[,]
                {
                    { 1, "C# Basic", 10 },
                    { 2, "C# Advanced", 15 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ActiveCourseId", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2002, 7, 2, 19, 26, 41, 936, DateTimeKind.Local).AddTicks(746), "Bob", "Bobsky" },
                    { 2, 2, new DateTime(1997, 7, 2, 19, 26, 41, 936, DateTimeKind.Local).AddTicks(798), "Jill", "Wayne" },
                    { 3, 1, new DateTime(2007, 7, 2, 19, 26, 41, 936, DateTimeKind.Local).AddTicks(802), "John", "Doe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ActiveCourseId",
                table: "Students",
                column: "ActiveCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
