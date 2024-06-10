using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TestForCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Series_CarTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RaceSeries");

            migrationBuilder.RenameColumn(
                name: "CarTypeId",
                table: "Cars",
                newName: "SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars",
                newName: "IX_Cars_SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Series_SeriesId",
                table: "Cars",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Series_SeriesId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "Cars",
                newName: "CarTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_SeriesId",
                table: "Cars",
                newName: "IX_Cars_CarTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RaceSeries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Series_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
