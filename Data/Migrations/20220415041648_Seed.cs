using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.Sql("INSERT INTO Items (Name, PluralName, Discriminator, DamageReduction, AmountToHeal, MinimumDamage, MaximumDamage) VALUES " +
                "('Rusty Sword', 'Rusty Swords', 'Weapon', NULL, NULL, 0, 5), " +
                "('Club', 'Clubs', 'Weapon', NULL, NULL, 1, 7), " +
                "('Rat Tail', 'Rat Tails', 'Item', NULL, NULL, NULL, NULL)," +
                "('Piece of Fur', 'Pieces of Fur', 'Item', NULL, NULL, NULL, NULL)," +
                "('Snake Fang', 'Snake Fangs', 'Item', NULL, NULL, NULL, NULL)," +
                "('Snake Skin', 'Snake Skins', 'Item', NULL, NULL, NULL, NULL)," +
                "('Spider Fang', 'Spider Fangs','Item', NULL, NULL, NULL, NULL)," +
                "('Silk Thread', 'Silk Threads','Item', NULL, NULL, NULL, NULL)," +
                "('Adventurer Pass', 'Adventurer Passes','Item', NULL, NULL, NULL, NULL)," +
                "('Healing Potion', 'Healing Potions','HealingPotion', NULL, 5, NULL, NULL)," +
                "('Leather Armor', 'Leather Armors','Armor', 4, NULL, NULL, NULL)," +
                "('Cloth Armor', 'Cloth Armors','Armor', 2, NULL, NULL, NULL);");
            
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
