using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class SeedLootTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO LootItems (DetailsItemID, DropRate, MinQuantity, MaxQuantity, EnemyID) VALUES " +
                "(15, 75, 1, 1, 1)," +
                "(16, 75, 1, 2, 1)," +
                "(17, 75, 1, 2, 2)," +
                "(18, 50, 1, 1, 2)," +
                "(20, 75, 2, 3, 3)," +
                "(19, 50, 1, 2, 3);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
