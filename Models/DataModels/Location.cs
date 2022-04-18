using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.DataModels
{
    public class Location
    {
        public int LocationID { get; set; }
        public String LocationName { get; set; }
        public String LocationDescription { get; set; }
        public Item? ItemRequiredToEnter { get; set; }
        public Quest? QuestAvailableHere { get; set; }
        public Enemy? EnemyFightHere { get; set; }
        public int? LocationToNorth { get; set; }
        public int? LocationToSouth { get; set; }
        public int? LocationToEast { get; set; }
        public int? LocationToWest { get; set; }
        
        public Location() { }

        public Location(int locationID, string locationName, Item itemRequiredToEnter, Quest questAvailableHere, Enemy enemyFightHere, 
            int locationToNorth, int locationToSouth, int locationToEast, int locationToWest)
        {
            LocationID = locationID;
            LocationName = locationName;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvailableHere = questAvailableHere;
            EnemyFightHere = enemyFightHere;
            LocationToNorth = locationToNorth;
            LocationToSouth = locationToSouth;
            LocationToEast = locationToEast;
            LocationToWest = locationToWest;
        }
    }
}
