using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTrack.Migrations
{
    public partial class AddRowNumberToCategoryItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RowOrder",
                table: "CategoryItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowOrder",
                table: "CategoryItems");
        }
    }
}
