using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_CreateById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CreateById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_CreateById",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_CreateById",
                table: "Threads");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Threads",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_CreateById",
                table: "Threads",
                newName: "IX_Threads_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Reactions",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_CreateById",
                table: "Reactions",
                newName: "IX_Reactions_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Comments",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CreateById",
                table: "Comments",
                newName: "IX_Comments_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Categories",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CreateById",
                table: "Categories",
                newName: "IX_Categories_CreatedById");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
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

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "ForumRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_ForumRoles_CreatedById",
                table: "ForumRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ForumRoles_DeletedById",
                table: "ForumRoles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ForumRoles_UpdatedById",
                table: "ForumRoles",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_CreatedById",
                table: "Categories",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedById",
                table: "Comments",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumRoles_AspNetUsers_CreatedById",
                table: "ForumRoles",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumRoles_AspNetUsers_DeletedById",
                table: "ForumRoles",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumRoles_AspNetUsers_UpdatedById",
                table: "ForumRoles",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_CreatedById",
                table: "Reactions",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_CreatedById",
                table: "Threads",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_CreatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumRoles_AspNetUsers_CreatedById",
                table: "ForumRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumRoles_AspNetUsers_DeletedById",
                table: "ForumRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumRoles_AspNetUsers_UpdatedById",
                table: "ForumRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_CreatedById",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_CreatedById",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_ForumRoles_CreatedById",
                table: "ForumRoles");

            migrationBuilder.DropIndex(
                name: "IX_ForumRoles_DeletedById",
                table: "ForumRoles");

            migrationBuilder.DropIndex(
                name: "IX_ForumRoles_UpdatedById",
                table: "ForumRoles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ForumRoles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ForumRoles");

            migrationBuilder.DropColumn(
                name: "DeletedById",
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

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Threads",
                newName: "CreateById");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_CreatedById",
                table: "Threads",
                newName: "IX_Threads_CreateById");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Reactions",
                newName: "CreateById");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_CreatedById",
                table: "Reactions",
                newName: "IX_Reactions_CreateById");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Comments",
                newName: "CreateById");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CreatedById",
                table: "Comments",
                newName: "IX_Comments_CreateById");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Categories",
                newName: "CreateById");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories",
                newName: "IX_Categories_CreateById");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_CreateById",
                table: "Categories",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CreateById",
                table: "Comments",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_CreateById",
                table: "Reactions",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_CreateById",
                table: "Threads",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
