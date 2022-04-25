using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.ViewModels
{
    public class PlayerCharacter : Creature
    {
        public string CharacterName { get; set; }
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int ExpNeededToLevel { get; set; }
        public int Level { get; set; }
        public Location CurrentLocationID { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public Armor CurrentArmor { get; set; }

        public PlayerCharacter()
        {
        }

        public PlayerCharacter(int currentHitPoints, int maximumHitpoints, int playerCharacterID, string userID, string characterName,
           int gold, int experiencePoints, int expNeededToLevel, int level, Location currentLocationID, Weapon currentWeapon, Armor currentArmor) : base(currentHitPoints, maximumHitpoints)
        {
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
