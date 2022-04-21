using AdventureProject.Models;
using AdventureProject.Models.DataModels;
using AdventureProject.Models.ViewModels;
using AdventureProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AdventureProject.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public GameController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {            
            var user = await _userManager.GetUserAsync(User);
            bool hasCharacter = _context.PlayerCharacters.Any(p => p.UserID == user.Id);
            if (!hasCharacter)
            {
                return RedirectToAction("Index", "CharacterController");
            }
            var tempPlayer = _context.PlayerCharacters.SingleOrDefault(p => p.UserID == user.Id);
            Models.ViewModels.Weapon playerWeapon = ConvertdmWeaponTovmWeapon(tempPlayer.CurrentWeapon);
            Models.ViewModels.Armor playerArmor = ConvertdmArmorTovmArmor(tempPlayer.CurrentArmor);
            Models.ViewModels.PlayerCharacter player = new Models.ViewModels.PlayerCharacter()
            {
                CharacterName = tempPlayer.CharacterName,
                Gold = tempPlayer.Gold,
                ExperiencePoints = tempPlayer.ExperiencePoints,
                ExpNeededToLevel = tempPlayer.ExpNeededToLevel,
                Level = tempPlayer.Level,
                CurrentLocationID = tempPlayer.CurrentLocationID,
                CurrentHitPoints = tempPlayer.CurrentHitPoints,
                MaximumHitPoints = tempPlayer.MaximumHitPoints,
                CurrentWeapon = playerWeapon,
                CurrentArmor = playerArmor
            };
            Models.ViewModels.Location location = 
                ConvertdmLocationTovmLocation(_context.Locations.SingleOrDefault(l => l.LocationID == player.CurrentLocationID));
            Models.ViewModels.Enemy enemy = location.EnemyFightHere;
            
            
            
            return View();
        }

        //method for datamodel to viewmodel conversion
        private Models.ViewModels.Weapon ConvertdmWeaponTovmWeapon(Models.DataModels.Weapon dmWeapon)
        {
            Models.ViewModels.Weapon vmWeapon = new Models.ViewModels.Weapon()
            {
                ItemID = dmWeapon.ItemID,
                Name = dmWeapon.Name,
                PluralName = dmWeapon.PluralName,
                MinimumDamage = dmWeapon.MinimumDamage,
                MaximumDamage = dmWeapon.MaximumDamage,
            };
            return vmWeapon;
        }

        private Models.ViewModels.Armor ConvertdmArmorTovmArmor(Models.DataModels.Armor dmArmor)
        {
            Models.ViewModels.Armor vmArmor = new Models.ViewModels.Armor()
            {
                ItemID = dmArmor.ItemID,
                Name = dmArmor.Name,
                PluralName = dmArmor.PluralName,
                DamageReduction = dmArmor.DamageReduction
            };
            return vmArmor;
        }

        private Models.ViewModels.Location ConvertdmLocationTovmLocation(Models.DataModels.Location dmLocation)
        {
            Models.ViewModels.Location vmLocation = new Models.ViewModels.Location()
            {
                LocationID = dmLocation.LocationID,
                LocationName = dmLocation.LocationName,
                LocationDescription = dmLocation.LocationDescription,
                ItemRequiredToEnter = ConvertdmItemtovmItem(dmLocation.ItemRequiredToEnter),
                QuestAvailableHere = ConvertdmQuesttovmQuest(dmLocation.QuestAvailableHere),
                EnemyFightHere = ConvertdmEnemytovmEnemy(dmLocation.EnemyFightHere),
                LocationToNorth = dmLocation.LocationToNorth,
                LocationToSouth = dmLocation.LocationToSouth,
                LocationToEast = dmLocation.LocationToEast,
                LocationToWest = dmLocation.LocationToWest
            };
            return vmLocation;
        }

        private Models.ViewModels.Item ConvertdmItemtovmItem(Models.DataModels.Item dmItem)
        {
            Models.ViewModels.Item vmItem = new Models.ViewModels.Item()
            {
                ItemID = dmItem.ItemID,
                Name = dmItem.Name,
                PluralName = dmItem.PluralName,
            };
            return vmItem;
        }

        private Models.ViewModels.Quest ConvertdmQuesttovmQuest(Models.DataModels.Quest dmQuest)
        {
            Models.ViewModels.Quest vmQuest = new Models.ViewModels.Quest()
            {
                QuestID = dmQuest.QuestID,
                QuestName = dmQuest.QuestName,
                QuestDescription = dmQuest.QuestDescription,
                RewardExperiencePoints = dmQuest.RewardExperiencePoints,
                RewardGold = dmQuest.RewardGold,
                RewardItem = ConvertdmItemtovmItem(dmQuest.RewardItem),
                QuestCompletionItem = ConvertdmQCItovmQCI(dmQuest.QuestCompletionItem)
            };
            return vmQuest;
        }

        private Models.ViewModels.QuestCompletionItem ConvertdmQCItovmQCI(Models.DataModels.QuestCompletionItem dmQCI)
        {
            Models.ViewModels.QuestCompletionItem vmQCI = new Models.ViewModels.QuestCompletionItem()
            {
                QuestCompletionItemID = dmQCI.QuestCompletionItemID,
                details = ConvertdmItemtovmItem(dmQCI.details),
                quantity = dmQCI.quantity
            };
            return vmQCI;
        }

        private Models.ViewModels.Enemy ConvertdmEnemytovmEnemy(Models.DataModels.Enemy dmEnemy)
        {
            List<Models.ViewModels.LootItem> lootTable = new List<Models.ViewModels.LootItem>();
            foreach(var lootItem in dmEnemy.LootTable)
            {
                lootTable.Add(ConvertdmLITovmLI(lootItem));
            }
            Models.ViewModels.Enemy vmEnemy = new Models.ViewModels.Enemy()
            {
                EnemyID = dmEnemy.EnemyID,
                EnemyName = dmEnemy.EnemyName,
                MinimumDamage = dmEnemy.MinimumDamage,
                MaximumDamage = dmEnemy.MaximumDamage,
                RewardExperience = dmEnemy.RewardExperience,
                RewardGold = dmEnemy.RewardGold,
                LootTable = lootTable
            };
            return vmEnemy;
        }

        private Models.ViewModels.LootItem ConvertdmLITovmLI(Models.DataModels.LootItem dmLI)
        {
            Models.ViewModels.LootItem vmLI = new Models.ViewModels.LootItem()
            {
                LootItemID = dmLI.LootItemID,
                Details = ConvertdmItemtovmItem(dmLI.Details),
                DropRate = dmLI.DropRate,
                MinQuantity = dmLI.MinQuantity,
                MaxQuantity = dmLI.MaxQuantity
            };
            return vmLI;
        }
    }
}
