using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoGear.Migrations
{
    /// <inheritdoc />
    public partial class LockoutEnabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: new Guid("b8dda1fd-f29b-49b7-b07b-d734f1f37f08"));

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.AddColumn<bool>(
                name: "IsLockedOut",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarName", "Speed" },
                values: new object[] { new Guid("73b67445-c7c0-4ad9-ad51-a309e88995b5"), "Мерседес", 100.0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { "3568DAFB-5617-4B95-9618-5572274FC621", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Email", "IsLockedOut", "LockoutEnabled", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { "E3B1A7AA-88EF-41E0-89B9-3803B8B54760", 0, "wpfsucks@mail.ru", false, true, "uiF2euSUr+WiFl3LMzjFMj6ZBwUONFQsQF1XXMMb9Sc=", null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3568DAFB-5617-4B95-9618-5572274FC621", "E3B1A7AA-88EF-41E0-89B9-3803B8B54760" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: new Guid("73b67445-c7c0-4ad9-ad51-a309e88995b5"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3568DAFB-5617-4B95-9618-5572274FC621", "E3B1A7AA-88EF-41E0-89B9-3803B8B54760" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3568DAFB-5617-4B95-9618-5572274FC621");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "E3B1A7AA-88EF-41E0-89B9-3803B8B54760");

            migrationBuilder.DropColumn(
                name: "IsLockedOut",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarName", "Speed" },
                values: new object[] { new Guid("b8dda1fd-f29b-49b7-b07b-d734f1f37f08"), "Мерседес", 100.0 });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
