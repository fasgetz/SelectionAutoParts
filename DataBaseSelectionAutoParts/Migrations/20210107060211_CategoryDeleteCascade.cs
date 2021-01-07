using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseSelectionAutoParts.Migrations
{
    public partial class CategoryDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_categories_ParentCategoryId",
                table: "categories");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_categories_ParentCategoryId",
                table: "categories",
                column: "ParentCategoryId",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_categories_ParentCategoryId",
                table: "categories");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_categories_ParentCategoryId",
                table: "categories",
                column: "ParentCategoryId",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
