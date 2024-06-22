using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WebHeaderId",
                table: "ProductCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_WebHeaderId",
                table: "ProductCategory",
                column: "WebHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_WebHeaders_WebHeaderId",
                table: "ProductCategory",
                column: "WebHeaderId",
                principalTable: "WebHeaders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_WebHeaders_WebHeaderId",
                table: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategory_WebHeaderId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "WebHeaderId",
                table: "ProductCategory");
        }
    }
}
