using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialEntitiesDesigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadReaction_Threads_ThreadId",
                table: "UserThreadReaction");

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadReaction_Threads_ThreadId",
                table: "UserThreadReaction",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadReaction_Threads_ThreadId",
                table: "UserThreadReaction");

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadReaction_Threads_ThreadId",
                table: "UserThreadReaction",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
