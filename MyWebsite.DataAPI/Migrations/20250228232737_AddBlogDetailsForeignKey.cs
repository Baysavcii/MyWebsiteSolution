using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebsite.DataAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogDetailsForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "BlogDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_BlogId",
                table: "BlogDetails",
                column: "BlogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogDetails_Blogs_BlogId",
                table: "BlogDetails",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_Blogs_BlogId",
                table: "BlogDetails");

            migrationBuilder.DropIndex(
                name: "IX_BlogDetails_BlogId",
                table: "BlogDetails");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogDetails");
        }
    }
}
