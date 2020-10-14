using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class SevenTeenMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StateId",
                table: "Bookings",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_State_StateId",
                table: "Bookings",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_State_StateId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StateId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
