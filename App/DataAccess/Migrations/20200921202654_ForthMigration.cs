using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ForthMigration : Migration
    {

        [ExcludeFromCodeCoverage]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_TouristPoints_TouristPointId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_TouristPoints_TouristPointId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_TouristPointId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TouristPointId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TouristPointId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "TouristPointId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "TouristPoints",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoints_RegionId",
                table: "TouristPoints",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_Regions_RegionId",
                table: "TouristPoints",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_Regions_RegionId",
                table: "TouristPoints");

            migrationBuilder.DropIndex(
                name: "IX_TouristPoints_RegionId",
                table: "TouristPoints");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "TouristPoints");

            migrationBuilder.AddColumn<int>(
                name: "TouristPointId",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TouristPointId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_TouristPointId",
                table: "Regions",
                column: "TouristPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TouristPointId",
                table: "Categories",
                column: "TouristPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_TouristPoints_TouristPointId",
                table: "Categories",
                column: "TouristPointId",
                principalTable: "TouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_TouristPoints_TouristPointId",
                table: "Regions",
                column: "TouristPointId",
                principalTable: "TouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
