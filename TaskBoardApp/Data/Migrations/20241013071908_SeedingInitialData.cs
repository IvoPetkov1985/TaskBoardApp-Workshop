using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedingInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "20cc05c5-c97b-4f6c-988f-ca026664c5aa", 0, "4cdda4cd-1e38-45e0-8691-259aa8bd3604", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAECGQ1MKCw4rDpUySXS0xWNegGWiguVHGVhpImVwyx363jQazJ6ezQjBtF5Oj6Ja0Ww==", null, false, "d6a5375b-2b17-4333-a443-9c64e61bde5f", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 27, 10, 19, 7, 566, DateTimeKind.Local).AddTicks(3178), "Implement better styling for all public pages", "20cc05c5-c97b-4f6c-988f-ca026664c5aa", "Improve CSS Styles" },
                    { 2, 1, new DateTime(2024, 5, 13, 10, 19, 7, 566, DateTimeKind.Local).AddTicks(3252), "Create Android client app for the TaskBoard RESTful API", "20cc05c5-c97b-4f6c-988f-ca026664c5aa", "Android Client App" },
                    { 3, 2, new DateTime(2024, 9, 13, 10, 19, 7, 566, DateTimeKind.Local).AddTicks(3271), "Create Windows Forms desktop client app for the TaskBoard RESTful API", "20cc05c5-c97b-4f6c-988f-ca026664c5aa", "Desktop Client App" },
                    { 4, 3, new DateTime(2023, 10, 13, 10, 19, 7, 566, DateTimeKind.Local).AddTicks(3291), "Implement [Create Task] page for adding new tasks", "20cc05c5-c97b-4f6c-988f-ca026664c5aa", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20cc05c5-c97b-4f6c-988f-ca026664c5aa");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
