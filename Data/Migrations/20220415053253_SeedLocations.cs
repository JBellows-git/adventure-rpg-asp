using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class SeedLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, LocationDescription, ItemRequiredToEnterItemID, QuestAvailableHereQuestID, EnemyFightHereEnemyID, LocationToNorth, LocationToSouth, LocationToEast,LocationToWest) VALUES " +
                "('Home', 'Your house. You really need to clean up the place.', NULL, NULL, NULL, 2, NULL, NULL, NULL)," +
                "('Town Square', 'You see a fountain in the center of the square', NULL, NULL, NULL, 3, 1, 7, 5)," +
                "('Alchemists Hut', 'There are many strange plants on the shelves', NULL, 1, NULL, 4, 2, NULL, NULL)," +
                "('Alchemists Garden', 'Many plants are growing here... and rats.', NULL, NULL, 1, NULL, 3, NULL, NULL)," +
                "('Farmhouse', 'There is a small farmhouse, with a farmer standing in front of it', NULL, 2, NULL, NULL, NULL, 2, 6)," +
                "('Farmers Field', 'You see a field of wheat', NULL, NULL, 2, NULL, NULL, 5, NULL)," +
                "('Gaurd Post', 'There is a large, tough-looking gaurd here.', 21, NULL, NULL, NULL, NULL, 8, 2)," +
                "('Bridge', 'A stone bridge crosses a wide river', NULL, NULL, NULL, NULL, NULL, 9, 7)," +
                "('Spider Forrest', 'You see a forrest covered with spider webs', NULL, NULL, 3, NULL, NULL, NULL, 8);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
