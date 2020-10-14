using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SixthMigration : Migration
    {
        [ExcludeFromCodeCoverage]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_Categories_CategoryId",
                table: "TouristPoints");

            migrationBuilder.DropIndex(
                name: "IX_TouristPoints_CategoryId",
                table: "TouristPoints");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TouristPoints");

            migrationBuilder.CreateTable(
                name: "CategoryTouristPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    TouristPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTouristPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTouristPoint_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTouristPoint_TouristPoints_TouristPointId",
                        column: x => x.TouristPointId,
                        principalTable: "TouristPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTouristPoint_CategoryId",
                table: "CategoryTouristPoint",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTouristPoint_TouristPointId",
                table: "CategoryTouristPoint",
                column: "TouristPointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTouristPoint");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TouristPoints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoints_CategoryId",
                table: "TouristPoints",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_Categories_CategoryId",
                table: "TouristPoints",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
