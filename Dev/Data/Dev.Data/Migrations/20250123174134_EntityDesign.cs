using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntityDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumRoles_AspNetUsers_CreateById",
                table: "ForumRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumRoles_AspNetUsers_Id",
                table: "ForumRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumRoles_AspNetUsers_UpdatedById",
                table: "ForumRoles");

            migrationBuilder.DropIndex(
                name: "IX_ForumRoles_CreateById",
                table: "ForumRoles");

            migrationBuilder.DropIndex(
                name: "IX_ForumRoles_UpdatedById",
                table: "ForumRoles");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "ForumRoles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ForumRoles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ForumRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ForumRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "ForumRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "ForumRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ForumRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ForumRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ForumRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "ForumRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ForumRoles_CreateById",
                table: "ForumRoles",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_ForumRoles_UpdatedById",
                table: "ForumRoles",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumRoles_AspNetUsers_CreateById",
                table: "ForumRoles",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumRoles_AspNetUsers_Id",
                table: "ForumRoles",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumRoles_AspNetUsers_UpdatedById",
                table: "ForumRoles",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
