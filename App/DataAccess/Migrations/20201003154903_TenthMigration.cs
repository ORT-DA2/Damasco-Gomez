using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class TenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Houses_HouseId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "HouseId",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Houses_HouseId",
                table: "Bookings",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Houses_HouseId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "HouseId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Houses_HouseId",
                table: "Bookings",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
