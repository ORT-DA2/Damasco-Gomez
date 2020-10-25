using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class TweentyEightMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.AlterColumn<int>(
                name: "ImageTouristPointId",
                table: "TouristPoints",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageTouristPointId",
                table: "TouristPoints",
                column: "ImageTouristPointId",
                principalTable: "ImageTouristPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.AlterColumn<int>(
                name: "ImageTouristPointId",
                table: "TouristPoints",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageTouristPointId",
                table: "TouristPoints",
                column: "ImageTouristPointId",
                principalTable: "ImageTouristPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
