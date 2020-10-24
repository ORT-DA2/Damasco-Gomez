using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class TwentyOneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "TouristPoints");

            migrationBuilder.DropColumn(
                name: "Ilustrations",
                table: "Houses");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "TouristPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entity = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    HouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoints_ImageId",
                table: "TouristPoints",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_HouseId",
                table: "Image",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_Image_ImageId",
                table: "TouristPoints",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_Image_ImageId",
                table: "TouristPoints");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_TouristPoints_ImageId",
                table: "TouristPoints");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "TouristPoints");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "TouristPoints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ilustrations",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
