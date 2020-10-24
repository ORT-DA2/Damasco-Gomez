using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class TweentyThreeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_Image_ImageId",
                table: "TouristPoints");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.CreateTable(
                name: "ImageHouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Extention = table.Column<string>(nullable: true),
                    HouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageHouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageHouse_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageTouristPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Extention = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTouristPoint", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageHouse_HouseId",
                table: "ImageHouse",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageId",
                table: "TouristPoints",
                column: "ImageId",
                principalTable: "ImageTouristPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_ImageTouristPoint_ImageId",
                table: "TouristPoints");

            migrationBuilder.DropTable(
                name: "ImageHouse");

            migrationBuilder.DropTable(
                name: "ImageTouristPoint");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
