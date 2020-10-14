using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class TwentyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTouristPoints_Categories_CategoryId",
                table: "CategoryTouristPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTouristPoints_TouristPoints_TouristPointId",
                table: "CategoryTouristPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTouristPoints",
                table: "CategoryTouristPoints");

            migrationBuilder.RenameTable(
                name: "CategoryTouristPoints",
                newName: "CategoriesTouristicPoints");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTouristPoints_TouristPointId",
                table: "CategoriesTouristicPoints",
                newName: "IX_CategoriesTouristicPoints_TouristPointId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTouristPoints_CategoryId",
                table: "CategoriesTouristicPoints",
                newName: "IX_CategoriesTouristicPoints_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesTouristicPoints",
                table: "CategoriesTouristicPoints",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesTouristicPoints_Categories_CategoryId",
                table: "CategoriesTouristicPoints",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesTouristicPoints_TouristPoints_TouristPointId",
                table: "CategoriesTouristicPoints",
                column: "TouristPointId",
                principalTable: "TouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesTouristicPoints_Categories_CategoryId",
                table: "CategoriesTouristicPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesTouristicPoints_TouristPoints_TouristPointId",
                table: "CategoriesTouristicPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesTouristicPoints",
                table: "CategoriesTouristicPoints");

            migrationBuilder.RenameTable(
                name: "CategoriesTouristicPoints",
                newName: "CategoryTouristPoints");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriesTouristicPoints_TouristPointId",
                table: "CategoryTouristPoints",
                newName: "IX_CategoryTouristPoints_TouristPointId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriesTouristicPoints_CategoryId",
                table: "CategoryTouristPoints",
                newName: "IX_CategoryTouristPoints_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTouristPoints",
                table: "CategoryTouristPoints",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTouristPoints_Categories_CategoryId",
                table: "CategoryTouristPoints",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTouristPoints_TouristPoints_TouristPointId",
                table: "CategoryTouristPoints",
                column: "TouristPointId",
                principalTable: "TouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
