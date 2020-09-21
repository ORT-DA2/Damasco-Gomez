using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_Regions_RegionId",
                table: "TouristPoints");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "TouristPoints",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TouristPoints",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_Regions_RegionId",
                table: "TouristPoints",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_Categories_CategoryId",
                table: "TouristPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_Regions_RegionId",
                table: "TouristPoints");

            migrationBuilder.DropIndex(
                name: "IX_TouristPoints_CategoryId",
                table: "TouristPoints");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TouristPoints");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "TouristPoints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_Regions_RegionId",
                table: "TouristPoints",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
