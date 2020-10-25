using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class ThirdtyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageHouses_Houses_HouseId",
                table: "ImageHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImageTouristPoints_ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageTouristPoints",
                table: "ImageTouristPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageHouses",
                table: "ImageHouses");

            migrationBuilder.RenameTable(
                name: "ImageTouristPoints",
                newName: "ImagesTouristPoints");

            migrationBuilder.RenameTable(
                name: "ImageHouses",
                newName: "ImagesHouses");

            migrationBuilder.RenameIndex(
                name: "IX_ImageHouses_HouseId",
                table: "ImagesHouses",
                newName: "IX_ImagesHouses_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesTouristPoints",
                table: "ImagesTouristPoints",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesHouses",
                table: "ImagesHouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesHouses_Houses_HouseId",
                table: "ImagesHouses",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_ImagesTouristPoints_ImageTouristPointId",
                table: "TouristPoints",
                column: "ImageTouristPointId",
                principalTable: "ImagesTouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesHouses_Houses_HouseId",
                table: "ImagesHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImagesTouristPoints_ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesTouristPoints",
                table: "ImagesTouristPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesHouses",
                table: "ImagesHouses");

            migrationBuilder.RenameTable(
                name: "ImagesTouristPoints",
                newName: "ImageTouristPoints");

            migrationBuilder.RenameTable(
                name: "ImagesHouses",
                newName: "ImageHouses");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesHouses_HouseId",
                table: "ImageHouses",
                newName: "IX_ImageHouses_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageTouristPoints",
                table: "ImageTouristPoints",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageHouses",
                table: "ImageHouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageHouses_Houses_HouseId",
                table: "ImageHouses",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_ImageTouristPoints_ImageTouristPointId",
                table: "TouristPoints",
                column: "ImageTouristPointId",
                principalTable: "ImageTouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
