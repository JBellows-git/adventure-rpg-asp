using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class SeedEnemies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Enemies (EnemyName, MinimumDamage, MaximumDamage, RewardExperience, RewardGold, CurrentHitPoints, MaximumHitpoints) VALUES" +
                   "('Rat', 1, 3, 5, 3, 3, 3)," +
                   "('Snake', 1, 4, 7, 4, 4, 4)," +
                   "('Giant Spider', 2, 6, 10, 6, 10, 10);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
