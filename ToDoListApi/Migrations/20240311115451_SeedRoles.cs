using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3860fd48-7bea-43f2-8213-0216df4165c3", null, "User", "USER" },
                    { "a76cd1a1-da8d-4426-b86a-513521883864", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 3, 11, 14, 54, 51, 483, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2024, 3, 11, 14, 54, 51, 483, DateTimeKind.Local).AddTicks(9460));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3860fd48-7bea-43f2-8213-0216df4165c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76cd1a1-da8d-4426-b86a-513521883864");

            migrationBuilder.UpdateData(
                table: "todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 3, 11, 12, 38, 22, 894, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2024, 3, 11, 12, 38, 22, 894, DateTimeKind.Local).AddTicks(8870));
        }
    }
}
