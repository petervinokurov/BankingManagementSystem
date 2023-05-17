using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UserClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId1",
                table: "RoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaims_RoleId1",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "RoleClaims");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserClaims",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserClaims");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "RoleClaims",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId1",
                table: "RoleClaims",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId1",
                table: "RoleClaims",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
