using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultRolesAdminSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("54b5f558-fe32-4f74-aa74-1ce1b7ca2ac0"), "e713754f-9c6a-48a8-b76d-e0bdacf43586", "Sales", "SALES" },
                    { new Guid("aa0bfc24-66aa-4b2e-8be4-71c50cb86e17"), "7caea4ba-7575-4131-9285-1b96caa2546b", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("54b5f558-fe32-4f74-aa74-1ce1b7ca2ac0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("aa0bfc24-66aa-4b2e-8be4-71c50cb86e17"));
        }
    }
}
