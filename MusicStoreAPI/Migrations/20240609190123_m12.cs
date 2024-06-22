using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class m12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "BasketElement");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BasketElement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "BasketElement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BasketElement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
