using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PiPA.Migrations.PADbcontextMigrations
{
    public partial class _031319rbuild31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListsTable",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TasksTable",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TasksTable",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TasksTable",
                keyColumn: "ID",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ListsTable",
                columns: new[] { "ID", "ListName", "UserID" },
                values: new object[] { 1, "ToDo", "1" });

            migrationBuilder.InsertData(
                table: "TasksTable",
                columns: new[] { "ID", "CompletedDate", "DateCreated", "Description", "IsComplete", "ListID", "PlannedDateComplete", "TaskName" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "Mow the lawn description", false, 1, new DateTime(2019, 3, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "Mow the Lawn" },
                    { 2, new DateTime(2019, 3, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 11, 7, 0, 0, 0, DateTimeKind.Unspecified), "Do the Dishes description", false, 1, new DateTime(2019, 3, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), "Do the Dishes" },
                    { 3, new DateTime(2019, 3, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 10, 7, 0, 0, 0, DateTimeKind.Unspecified), "Go Grocery Shopping description", false, 1, new DateTime(2019, 3, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), "Go Grocery Shopping" }
                });
        }
    }
}
