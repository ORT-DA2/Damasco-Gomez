using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class EightTeenMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_State_StateId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_States_StateId",
                table: "Bookings",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_States_StateId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_State_StateId",
                table: "Bookings",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
