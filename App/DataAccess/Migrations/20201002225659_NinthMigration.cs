using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NinthMigration : Migration
    {
        [ExcludeFromCodeCoverage]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_TouristPoints_SpotId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_SpotId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "HouseName",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "SpotId",
                table: "Houses");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Houses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouristPointId",
                table: "Houses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_TouristPointId",
                table: "Houses",
                column: "TouristPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_TouristPoints_TouristPointId",
                table: "Houses",
                column: "TouristPointId",
                principalTable: "TouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_TouristPoints_TouristPointId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_TouristPointId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "TouristPointId",
                table: "Houses");

            migrationBuilder.AddColumn<string>(
                name: "HouseName",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpotId",
                table: "Houses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_SpotId",
                table: "Houses",
                column: "SpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_TouristPoints_SpotId",
                table: "Houses",
                column: "SpotId",
                principalTable: "TouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
