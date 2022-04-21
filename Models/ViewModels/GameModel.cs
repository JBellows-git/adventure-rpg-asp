using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.ViewModels
{
    public class GameModel
    {
        public PlayerCharacter Player { get; set; }
        public Location Location { get; set; }
        public Enemy Enemy { get; set; }
        public Quest Quest { get; set; }        
        public List<QuestLog> QuestLog { get; set; }        
        public List<Inventory> Inventory { get; set; }

        public GameModel() { }

        public GameModel(PlayerCharacter player, Location location, Enemy enemy, Quest quest, List<QuestLog> questLog, List<Inventory> inventory)
        {
            Player = player;
            Location = location;
            Enemy = enemy;
            Quest = quest;
            QuestLog = questLog;
            Inventory = inventory;
        }
    }
}
