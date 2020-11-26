using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class TweentyFourMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageId",
                table: "TouristPoints");

            migrationBuilder.DropIndex(
                name: "IX_TouristPoints_ImageId",
                table: "TouristPoints");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "TouristPoints");

            migrationBuilder.AddColumn<int>(
                name: "ImageTouristPointId",
                table: "TouristPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoints_ImageTouristPointId",
                table: "TouristPoints",
                column: "ImageTouristPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageTouristPointId",
                table: "TouristPoints",
                column: "ImageTouristPointId",
                principalTable: "ImageTouristPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.DropIndex(
                name: "IX_TouristPoints_ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.DropColumn(
                name: "ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "TouristPoints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoints_ImageId",
                table: "TouristPoints",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageId",
                table: "TouristPoints",
                column: "ImageId",
                principalTable: "ImageTouristPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
