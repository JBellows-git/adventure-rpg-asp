using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class PlayerCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerCharacters",
                columns: table => new
                {
                    PlayerCharacterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ExperiencePoints = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ExpNeededToLevel = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    Level = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CurrentLocationID = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CurrentHitPoints = table.Column<int>(type: "int", nullable: false),
                    MaximumHitPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacters", x => x.PlayerCharacterID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerCharacters");
        }
    }
}
