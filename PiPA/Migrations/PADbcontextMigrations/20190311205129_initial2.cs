using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PiPA.Migrations.PADbcontextMigrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListsTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    ListName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListsTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TasksTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListID = table.Column<int>(nullable: false),
                    TaskName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    PlannedDateComplete = table.Column<DateTime>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksTable", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListsTable");

            migrationBuilder.DropTable(
                name: "TasksTable");
        }
    }
}
