using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("779f3783-e69a-4265-b92f-188943ed3be8"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bdeeb364-5b9e-4920-8226-0646b9267875", "f0fae09f-e633-48a7-986b-fd52d6770c53" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("779f3783-e69a-4265-b92f-188943ed3be8"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5802e3e-bdca-4f71-a3e1-8aa915684a48", "b8f04111-b46b-4cf5-81a4-2131de2c8e8f" });
        }
    }
}
