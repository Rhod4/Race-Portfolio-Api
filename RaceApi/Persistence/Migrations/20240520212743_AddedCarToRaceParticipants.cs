using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCarToRaceParticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "RaceParticipants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipants_CarId",
                table: "RaceParticipants",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceParticipants_Cars_CarId",
                table: "RaceParticipants",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceParticipants_Cars_CarId",
                table: "RaceParticipants");

            migrationBuilder.DropIndex(
                name: "IX_RaceParticipants_CarId",
                table: "RaceParticipants");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "RaceParticipants");
        }
    }
}
