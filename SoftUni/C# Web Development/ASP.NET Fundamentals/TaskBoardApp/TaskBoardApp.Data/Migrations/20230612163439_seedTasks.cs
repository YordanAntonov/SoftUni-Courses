using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class seedTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 24, 16, 34, 38, 881, DateTimeKind.Utc).AddTicks(5998), "Implement better styling for all public pages", "3beadded-107d-4357-956e-d490754c07b3", "Improve CSS styles" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { 2, 2, new DateTime(2023, 6, 2, 16, 34, 38, 881, DateTimeKind.Utc).AddTicks(6005), "Create Android Client App for the TaskBoard RESTful API", "3beadded-107d-4357-956e-d490754c07b3", "Android Client App" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { 3, 3, new DateTime(2023, 5, 3, 16, 34, 38, 881, DateTimeKind.Utc).AddTicks(6007), "Create Windows Forms desktop app client for the taskBoard App RESTful API", "3beadded-107d-4357-956e-d490754c07b3", "Desktop Client App" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });
        }
    }
}
