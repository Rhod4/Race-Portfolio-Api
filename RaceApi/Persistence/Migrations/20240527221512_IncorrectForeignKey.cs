using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IncorrectForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSeries_Game_RaceId",
                table: "GameSeries");

            migrationBuilder.DropIndex(
                name: "IX_GameSeries_RaceId",
                table: "GameSeries");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "GameSeries");

            migrationBuilder.CreateIndex(
                name: "IX_GameSeries_GameId",
                table: "GameSeries",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSeries_Game_GameId",
                table: "GameSeries",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSeries_Game_GameId",
                table: "GameSeries");

            migrationBuilder.DropIndex(
                name: "IX_GameSeries_GameId",
                table: "GameSeries");

            migrationBuilder.AddColumn<Guid>(
                name: "RaceId",
                table: "GameSeries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GameSeries_RaceId",
                table: "GameSeries",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSeries_Game_RaceId",
                table: "GameSeries",
                column: "RaceId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
