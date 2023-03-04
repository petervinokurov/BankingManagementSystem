using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixedDefaultValuesForStamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("779f3783-e69a-4265-b92f-188943ed3be8"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "748a2661-93d0-41e1-9241-7272efa184da", "748a2661-93d0-41e1-9241-7272efa184da" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("779f3783-e69a-4265-b92f-188943ed3be8"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bdeeb364-5b9e-4920-8226-0646b9267875", "f0fae09f-e633-48a7-986b-fd52d6770c53" });
        }
    }
}
