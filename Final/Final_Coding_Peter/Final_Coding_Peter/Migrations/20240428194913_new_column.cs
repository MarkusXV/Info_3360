using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final_Coding_Peter.Migrations
{
    /// <inheritdoc />
    public partial class new_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Workers_WorkerID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_WorkerID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "WorkerID",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "WorkerName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "WorkerName",
                value: "Ester");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                column: "WorkerName",
                value: "Fred");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                column: "WorkerName",
                value: "Bruce");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerName",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "WorkerID",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "WorkerID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                column: "WorkerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                column: "WorkerID",
                value: 3);

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "WorkerID", "Firstname", "Lastname", "Position" },
                values: new object[,]
                {
                    { 1, "Fred", "Ballard", "Accountant" },
                    { 2, "Ester", "Frederick", "HR" },
                    { 3, "Bruce", "Ford", "CEO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkerID",
                table: "Tasks",
                column: "WorkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Workers_WorkerID",
                table: "Tasks",
                column: "WorkerID",
                principalTable: "Workers",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
