using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("779f3783-e69a-4265-b92f-188943ed3be8"), 0, "c5802e3e-bdca-4f71-a3e1-8aa915684a48", "admin@irocbank.com", false, false, null, "ADMIN@IROCBANK.COM", null, "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", null, false, "b8f04111-b46b-4cf5-81a4-2131de2c8e8f", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("779f3783-e69a-4265-b92f-188943ed3be8"));
        }
    }
}
