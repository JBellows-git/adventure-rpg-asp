using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class playerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLocationID",
                table: "PlayerCharacters");

            migrationBuilder.AddColumn<int>(
                name: "CurrentLocationIDLocationID",
                table: "PlayerCharacters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_CurrentLocationIDLocationID",
                table: "PlayerCharacters",
                column: "CurrentLocationIDLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_Locations_CurrentLocationIDLocationID",
                table: "PlayerCharacters",
                column: "CurrentLocationIDLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_Locations_CurrentLocationIDLocationID",
                table: "PlayerCharacters");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacters_CurrentLocationIDLocationID",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "CurrentLocationIDLocationID",
                table: "PlayerCharacters");

            migrationBuilder.AddColumn<int>(
                name: "CurrentLocationID",
                table: "PlayerCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
