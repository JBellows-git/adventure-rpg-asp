using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.DataModels
{
    public class Enemy : Creature
    {
        public int EnemyID { get; set; }
        public String EnemyName { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperience { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }

        public Enemy() : base() { }

        public Enemy(int currentHitPoints, int maximumHitPoints, int enemyID, string enemyName, int minimumDamage, int maximumDamage, 
            int rewardExperience, int rewardGold) : base(currentHitPoints, maximumHitPoints)
        {
            EnemyID = enemyID;
            EnemyName = enemyName;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperience = rewardExperience;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();
        }
    }
}
