using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class IdentityFrameworkRoleClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RoleClaims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RoleClaims",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
