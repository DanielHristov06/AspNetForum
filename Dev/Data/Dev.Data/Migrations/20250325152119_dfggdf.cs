using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class dfggdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Comments_CommentId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_CommentId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                newName: "IX_Comments_ParentId");

            migrationBuilder.CreateTable(
                name: "AttachmentComment",
                columns: table => new
                {
                    AttachmentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentComment", x => new { x.AttachmentsId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_AttachmentComment_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentComment_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentDevThread",
                columns: table => new
                {
                    AttachmentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DevThreadId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentDevThread", x => new { x.AttachmentsId, x.DevThreadId });
                    table.ForeignKey(
                        name: "FK_AttachmentDevThread_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentDevThread_DevThread_DevThreadId",
                        column: x => x.DevThreadId,
                        principalTable: "DevThread",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentComment_CommentId",
                table: "AttachmentComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentDevThread_DevThreadId",
                table: "AttachmentDevThread",
                column: "DevThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments",
                column: "ParentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "AttachmentComment");

            migrationBuilder.DropTable(
                name: "AttachmentDevThread");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                newName: "IX_Comments_CommentId");

            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "Attachments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CommentId",
                table: "Attachments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Comments_CommentId",
                table: "Attachments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
