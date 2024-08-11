using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final_Coding_Peter.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Workers_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "Workers",
                        principalColumn: "WorkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "WorkerID", "Firstname", "Lastname", "Position" },
                values: new object[,]
                {
                    { 1, "Fred", "Ballard", "Accountant" },
                    { 2, "Ester", "Frederick", "HR" },
                    { 3, "Bruce", "Ford", "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Description", "DueDate", "Status", "Title", "WorkerID" },
                values: new object[,]
                {
                    { 1, "We need to hire 3 new people for our support staff.", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Hire new personnel", 2 },
                    { 2, "File Taxes for last year", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Past Due", "Finish Taxes", 1 },
                    { 3, "Board Meeting needs to be conducted at the end of the Quarter", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "Have a Board Meeting", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkerID",
                table: "Tasks",
                column: "WorkerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
