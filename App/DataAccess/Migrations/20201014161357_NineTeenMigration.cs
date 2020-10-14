using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NineTeenMigration : Migration
    {
        [ExcludeFromCodeCoverage]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTouristPoint_Categories_CategoryId",
                table: "CategoryTouristPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTouristPoint_TouristPoints_TouristPointId",
                table: "CategoryTouristPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTouristPoint",
                table: "CategoryTouristPoint");

            migrationBuilder.RenameTable(
                name: "CategoryTouristPoint",
                newName: "CategoryTouristPoints");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTouristPoint_TouristPointId",
                table: "CategoryTouristPoints",
                newName: "IX_CategoryTouristPoints_TouristPointId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTouristPoint_CategoryId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "CategoryTouristPoint");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTouristPoints_TouristPointId",
                table: "CategoryTouristPoint",
                newName: "IX_CategoryTouristPoint_TouristPointId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTouristPoints_CategoryId",
                table: "CategoryTouristPoint",
                newName: "IX_CategoryTouristPoint_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTouristPoint",
                table: "CategoryTouristPoint",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTouristPoint_Categories_CategoryId",
                table: "CategoryTouristPoint",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTouristPoint_TouristPoints_TouristPointId",
                table: "CategoryTouristPoint",
                column: "TouristPointId",
                principalTable: "TouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
