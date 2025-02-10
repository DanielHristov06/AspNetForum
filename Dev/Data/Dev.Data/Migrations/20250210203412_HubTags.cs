using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class HubTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevTag_DevThread_DevThreadId",
                table: "DevTag");

            migrationBuilder.DropForeignKey(
                name: "FK_DevTag_Hubs_HubId",
                table: "DevTag");

            migrationBuilder.DropIndex(
                name: "IX_DevTag_DevThreadId",
                table: "DevTag");

            migrationBuilder.DropIndex(
                name: "IX_DevTag_HubId",
                table: "DevTag");

            migrationBuilder.DropColumn(
                name: "DevThreadId",
                table: "DevTag");

            migrationBuilder.DropColumn(
                name: "HubId",
                table: "DevTag");

            migrationBuilder.CreateTable(
                name: "DevTagDevThread",
                columns: table => new
                {
                    DevThreadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevTagDevThread", x => new { x.DevThreadId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_DevTagDevThread_DevTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "DevTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevTagDevThread_DevThread_DevThreadId",
                        column: x => x.DevThreadId,
                        principalTable: "DevThread",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevTagHub",
                columns: table => new
                {
                    HubId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevTagHub", x => new { x.HubId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_DevTagHub_DevTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "DevTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevTagHub_Hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "Hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevTagDevThread_TagsId",
                table: "DevTagDevThread",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_DevTagHub_TagsId",
                table: "DevTagHub",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevTagDevThread");

            migrationBuilder.DropTable(
                name: "DevTagHub");

            migrationBuilder.AddColumn<string>(
                name: "DevThreadId",
                table: "DevTag",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HubId",
                table: "DevTag",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DevTag_DevThreadId",
                table: "DevTag",
                column: "DevThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_DevTag_HubId",
                table: "DevTag",
                column: "HubId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevTag_DevThread_DevThreadId",
                table: "DevTag",
                column: "DevThreadId",
                principalTable: "DevThread",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DevTag_Hubs_HubId",
                table: "DevTag",
                column: "HubId",
                principalTable: "Hubs",
                principalColumn: "Id");
        }
    }
}
