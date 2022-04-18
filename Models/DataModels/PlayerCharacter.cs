using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.DataModels
{
    public class PlayerCharacter : Creature
    {
        public int PlayerCharacterID { get; set; }
        public String UserID { get; set; }
        public String CharacterName { get; set; }        
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int ExpNeededToLevel { get; set; }
        public int Level { get; set; }
        public int CurrentLocationID { get; set; }
        //Item IDs go here when constructing
        public Weapon CurrentWeapon { get; set; }
        public Armor CurrentArmor { get; set; }


        public PlayerCharacter() : base (){ }

        public PlayerCharacter(int currentHitPoints, int maximumHitpoints, int playerCharacterID, string userID, string characterName,
            int gold, int experiencePoints, int expNeededToLevel, int level, int currentLocationID, Weapon currentWeapon, Armor currentArmor) : base(currentHitPoints, maximumHitpoints)
        {
            PlayerCharacterID = playerCharacterID;
            UserID = userID;
            CharacterName = characterName;
            Gold = gold;
            ExperiencePoints = experiencePoints;
            ExpNeededToLevel = expNeededToLevel;
            Level = level;
            CurrentLocationID = currentLocationID;
            CurrentWeapon = currentWeapon;
            CurrentArmor = currentArmor;
        }
    }
}
