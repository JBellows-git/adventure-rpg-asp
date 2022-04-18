using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class SeedQuestCompletionItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO QuestCompletionItems (detailsItemID, quantity) VALUES " +
                "(15, 3)," +
                "(17, 4);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
