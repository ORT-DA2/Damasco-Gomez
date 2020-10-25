using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class TweentyNineMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageHouse_Houses_HouseId",
                table: "ImageHouse");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageTouristPoint",
                table: "ImageTouristPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageHouse",
                table: "ImageHouse");

            migrationBuilder.RenameTable(
                name: "ImageTouristPoint",
                newName: "ImageTouristPoints");

            migrationBuilder.RenameTable(
                name: "ImageHouse",
                newName: "ImageHouses");

            migrationBuilder.RenameIndex(
                name: "IX_ImageHouse_HouseId",
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

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HouseId",
                table: "Reviews",
                column: "HouseId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageHouses_Houses_HouseId",
                table: "ImageHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImageTouristPoints_ImageTouristPointId",
                table: "TouristPoints");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageTouristPoints",
                table: "ImageTouristPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageHouses",
                table: "ImageHouses");

            migrationBuilder.RenameTable(
                name: "ImageTouristPoints",
                newName: "ImageTouristPoint");

            migrationBuilder.RenameTable(
                name: "ImageHouses",
                newName: "ImageHouse");

            migrationBuilder.RenameIndex(
                name: "IX_ImageHouses_HouseId",
                table: "ImageHouse",
                newName: "IX_ImageHouse_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageTouristPoint",
                table: "ImageTouristPoint",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageHouse",
                table: "ImageHouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageHouse_Houses_HouseId",
                table: "ImageHouse",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageTouristPointId",
                table: "TouristPoints",
                column: "ImageTouristPointId",
                principalTable: "ImageTouristPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
