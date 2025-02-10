using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Hub_Tag_GenericConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_CreatedById",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_DeletedById",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_UpdatedById",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Categories_CategoryId",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadComment_Threads_ThreadId",
                table: "UserThreadComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadReaction_Threads_ThreadId",
                table: "UserThreadReaction");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Threads",
                table: "Threads");

            migrationBuilder.RenameTable(
                name: "Threads",
                newName: "DevThread");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "DevThread",
                newName: "HubId");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_UpdatedById",
                table: "DevThread",
                newName: "IX_DevThread_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_DeletedById",
                table: "DevThread",
                newName: "IX_DevThread_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_CreatedById",
                table: "DevThread",
                newName: "IX_DevThread_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_CategoryId",
                table: "DevThread",
                newName: "IX_DevThread_HubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevThread",
                table: "DevThread",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Hubs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HubPhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BannerPhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hubs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hubs_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hubs_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hubs_Attachments_BannerPhotoId",
                        column: x => x.BannerPhotoId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hubs_Attachments_HubPhotoId",
                        column: x => x.HubPhotoId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DevTag",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevThreadId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HubId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevTag_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DevTag_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DevTag_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DevTag_DevThread_DevThreadId",
                        column: x => x.DevThreadId,
                        principalTable: "DevThread",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DevTag_Hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "Hubs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevTag_CreatedById",
                table: "DevTag",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DevTag_DeletedById",
                table: "DevTag",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DevTag_DevThreadId",
                table: "DevTag",
                column: "DevThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_DevTag_HubId",
                table: "DevTag",
                column: "HubId");

            migrationBuilder.CreateIndex(
                name: "IX_DevTag_UpdatedById",
                table: "DevTag",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_BannerPhotoId",
                table: "Hubs",
                column: "BannerPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_CreatedById",
                table: "Hubs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_DeletedById",
                table: "Hubs",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_HubPhotoId",
                table: "Hubs",
                column: "HubPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_UpdatedById",
                table: "Hubs",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DevThread_AspNetUsers_CreatedById",
                table: "DevThread",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DevThread_AspNetUsers_DeletedById",
                table: "DevThread",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DevThread_AspNetUsers_UpdatedById",
                table: "DevThread",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DevThread_Hubs_HubId",
                table: "DevThread",
                column: "HubId",
                principalTable: "Hubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadComment_DevThread_ThreadId",
                table: "UserThreadComment",
                column: "ThreadId",
                principalTable: "DevThread",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadReaction_DevThread_ThreadId",
                table: "UserThreadReaction",
                column: "ThreadId",
                principalTable: "DevThread",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevThread_AspNetUsers_CreatedById",
                table: "DevThread");

            migrationBuilder.DropForeignKey(
                name: "FK_DevThread_AspNetUsers_DeletedById",
                table: "DevThread");

            migrationBuilder.DropForeignKey(
                name: "FK_DevThread_AspNetUsers_UpdatedById",
                table: "DevThread");

            migrationBuilder.DropForeignKey(
                name: "FK_DevThread_Hubs_HubId",
                table: "DevThread");

            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadComment_DevThread_ThreadId",
                table: "UserThreadComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadReaction_DevThread_ThreadId",
                table: "UserThreadReaction");

            migrationBuilder.DropTable(
                name: "DevTag");

            migrationBuilder.DropTable(
                name: "Hubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevThread",
                table: "DevThread");

            migrationBuilder.RenameTable(
                name: "DevThread",
                newName: "Threads");

            migrationBuilder.RenameColumn(
                name: "HubId",
                table: "Threads",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DevThread_UpdatedById",
                table: "Threads",
                newName: "IX_Threads_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_DevThread_HubId",
                table: "Threads",
                newName: "IX_Threads_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DevThread_DeletedById",
                table: "Threads",
                newName: "IX_Threads_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_DevThread_CreatedById",
                table: "Threads",
                newName: "IX_Threads_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Threads",
                table: "Threads",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoverPhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Attachments_CoverPhotoId",
                        column: x => x.CoverPhotoId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CoverPhotoId",
                table: "Categories",
                column: "CoverPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeletedById",
                table: "Categories",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedById",
                table: "Categories",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_CreatedById",
                table: "Threads",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_DeletedById",
                table: "Threads",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_UpdatedById",
                table: "Threads",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Categories_CategoryId",
                table: "Threads",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadComment_Threads_ThreadId",
                table: "UserThreadComment",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadReaction_Threads_ThreadId",
                table: "UserThreadReaction",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
