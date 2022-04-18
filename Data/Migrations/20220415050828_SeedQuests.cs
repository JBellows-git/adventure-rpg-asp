using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class SeedQuests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Quests (QuestName, QuestDescription, RewardExperiencePoints, RewardGold, RewardItemItemID, QuestCompletionItemID) VALUES " +
                "('Clear the alchemists garden', 'Kill rats in the alchemists garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.', 20, 10, 22, 2)," +
                "('Clear the farmers field', 'Kill snakes in the farmers field and bring back 3 snake fangs. You will receive an adventurers pass and 20 gold pieces.', 30, 20, 21, 3);");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
