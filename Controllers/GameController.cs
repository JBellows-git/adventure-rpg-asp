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
using Microsoft.EntityFrameworkCore;

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
                return RedirectToAction("Index", "Character");
            }
            
            Models.DataModels.PlayerCharacter tempPC = _context.PlayerCharacters.SingleOrDefault(p => p.UserID == user.Id);
            var test = _context.PlayerCharacters.Where(p => p.UserID == user.Id).Select(p => new { p.CurrentArmor, p.CurrentLocationID, p.CurrentWeapon }).FirstOrDefault();
            Models.ViewModels.PlayerCharacter player = ConvertdmPCtovmPC(tempPC);

            Models.ViewModels.Location location = 
                ConvertdmLocationTovmLocation(_context.Locations.SingleOrDefault(l => l.LocationID == player.CurrentLocationID.LocationID));

            Models.ViewModels.Enemy enemy = new Models.ViewModels.Enemy();
            var testFight = _context.Locations.Where(l => l.LocationID == player.CurrentLocationID.LocationID).Select(l => l.EnemyFightHere.EnemyID);
            try
            {
                var enemyID = testFight.SingleOrDefault();
                Models.DataModels.Enemy tempEnemy = _context.Enemies.SingleOrDefault(e => e.EnemyID == enemyID);
                var lootList = _context.LootItems.FromSqlRaw("SELECT * FROM LootItems WHERE EnemyID = {0}", tempEnemy.EnemyID);
                List<Models.DataModels.LootItem> lootTable = new List<Models.DataModels.LootItem>();
                foreach(var lootItem in lootList)
                {
                    var lootItemID = _context.LootItems.Where(li => li.LootItemID == lootItem.LootItemID).Select(li => li.Details.ItemID);
                    var liID = lootItemID.SingleOrDefault();
                    var loot = _context.Items.SingleOrDefault(i => i.ItemID == liID);
                    lootItem.Details = loot;
                    lootTable.Add(lootItem);
                }
                tempEnemy.LootTable = lootTable;
                enemy = ConvertdmEnemytovmEnemy(tempEnemy);
                location.EnemyFightHere = enemy;
            }catch { }

            var testloc = _context.Locations.Where(l => l.LocationID == player.CurrentLocationID.LocationID).Select(l => l.QuestAvailableHere.QuestID);            
            Models.ViewModels.Quest quest = new Models.ViewModels.Quest();
            try
            {
                var questID = testloc.SingleOrDefault();
                Models.DataModels.Quest tempQuest = _context.Quests.SingleOrDefault(q => q.QuestID == questID);
                var questrewarditemID = _context.Quests.Where(q => q.QuestID == questID).Select(q => q.RewardItem.ItemID);
                var qrID = questrewarditemID.FirstOrDefault();
                var rewardItem = _context.Items.SingleOrDefault(i => i.ItemID == qrID);
                tempQuest.RewardItem = rewardItem;
                var questCompItemID = _context.Quests.Where(q => q.QuestID == questID).Select(q => q.QuestCompletionItem.QuestCompletionItemID);
                var qcID = questCompItemID.FirstOrDefault();
                var questcompletionItem = _context.QuestCompletionItems.SingleOrDefault(qc => qc.QuestCompletionItemID == qcID);
                tempQuest.QuestCompletionItem = questcompletionItem;
                var questCompDetailID = _context.Quests.Where(q => q.QuestID == questID).Select(q => q.QuestCompletionItem.details.ItemID);
                var detailID = questCompDetailID.FirstOrDefault();
                var detailItem = _context.Items.SingleOrDefault(i => i.ItemID == detailID);
                tempQuest.QuestCompletionItem.details = detailItem;
                quest = ConvertdmQuesttovmQuest(tempQuest);
                location.QuestAvailableHere = quest;
            } catch { }

            List<Models.ViewModels.QuestLog> questLog = new List<Models.ViewModels.QuestLog>();
            var qLog = _context.QuestLogs.Where(x => x.Player.CharacterName == player.CharacterName);
            try
            {
                foreach (var q in qLog) // q = quest
                {
                    var qlQuestId = _context.QuestLogs.Where(ql => ql.QuestLogID == q.QuestLogID).Select(ql => ql.CollectedQuest.QuestID);
                    var qlQID = qlQuestId.FirstOrDefault();
                    var questLogQID = _context.Quests.SingleOrDefault(q => q.QuestID == qlQID);

                    var questrewarditemID = _context.Quests.Where(q => q.QuestID == qlQID).Select(q => q.RewardItem.ItemID);
                    var qrID = questrewarditemID.FirstOrDefault();
                    var rewardItem = _context.Items.SingleOrDefault(i => i.ItemID == qrID);
                    questLogQID.RewardItem = rewardItem;

                    var questCompItemID = _context.Quests.Where(q => q.QuestID == qlQID).Select(q => q.QuestCompletionItem.QuestCompletionItemID);
                    var qcID = questCompItemID.FirstOrDefault();
                    var questcompletionItem = _context.QuestCompletionItems.SingleOrDefault(qc => qc.QuestCompletionItemID == qcID);
                    questLogQID.QuestCompletionItem = questcompletionItem;

                    var questCompDetailID = _context.Quests.Where(q => q.QuestID == qlQID).Select(q => q.QuestCompletionItem.details.ItemID);
                    var detailID = questCompDetailID.FirstOrDefault();
                    var detailItem = _context.Items.SingleOrDefault(i => i.ItemID == detailID);
                    questLogQID.QuestCompletionItem.details = detailItem;
                    q.CollectedQuest = questLogQID;
                    questLog.Add(ConvertdmQLogTovmQLog(q));
                }
            }
            catch { }
            List<Models.ViewModels.Inventory> pcInventory = new List<Models.ViewModels.Inventory>();
            var inventory = _context.Inventories.Where(i => i.PlayerCharacter.CharacterName == player.CharacterName).Select(i => new { i.InventoryID, i.PlayerCharacter, i.Detail, i.Quantity });           
            if (inventory != null)
            {
                foreach(var i in inventory)
                {
                    Models.DataModels.Inventory temp = new Models.DataModels.Inventory()
                    {
                        InventoryID = i.InventoryID,
                        PlayerCharacter = i.PlayerCharacter,
                        Detail = i.Detail,
                        Quantity = i.Quantity
                    };
                    pcInventory.Add(ConvertdmInventoryTovmInventory(temp));
                }
            }
            List<Models.ViewModels.Inventory> weaponList = new List<Models.ViewModels.Inventory>();
            var weaponQuery = _context.Inventories.FromSqlRaw("SELECT * FROM Inventories WHERE PlayerCharacterID = {0} AND DetailItemID in (SELECT ItemID From Items WHERE MinimumDamage >= 0)", tempPC.PlayerCharacterID);
            foreach(var weapon in weaponQuery)
            {
                weaponList.Add(ConvertdmInventoryTovmInventory(weapon));
            }
            List<Models.ViewModels.Inventory> armorList = new List<Models.ViewModels.Inventory>();
            var armorQuery = _context.Inventories.FromSqlRaw("SELECT * FROM Inventories WHERE PlayerCharacterID = {0} AND DetailItemID in (SELECT ItemID From Items WHERE DamageReduction >= 0)", tempPC.PlayerCharacterID);
            foreach(var armor in armorQuery)
            {
                armorList.Add(ConvertdmInventoryTovmInventory(armor));
            }
            ViewBag.weaponList = weaponList;
            ViewBag.armorList = armorList;
            GameModel game = new GameModel()
            {
                Player = player,
                Location = location,
                Enemy = enemy,
                Quest = quest,
                QuestLog = questLog,
                Inventory = pcInventory
            };
            return View(game);
        }

        //move player to new location
        [HttpPost]
        public IActionResult Move(int newLocation, string player)
        {
            var result = _context.PlayerCharacters.SingleOrDefault(p => p.CharacterName == player);
            //Models.DataModels.Location moveTo = _context.Locations.SingleOrDefault(l => l.LocationID == newLocation);
            result.CurrentLocationID = _context.Locations.SingleOrDefault(l => l.LocationID == newLocation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeWeapon(int weapon, string player)
        {
            var result = _context.PlayerCharacters.SingleOrDefault(p => p.CharacterName == player);
            result.CurrentWeapon = (Models.DataModels.Weapon)_context.Items.SingleOrDefault(w => w.ItemID == weapon);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeArmor(int armor, string player)
        {
            var result = _context.PlayerCharacters.SingleOrDefault(p => p.CharacterName == player);
            result.CurrentArmor = (Models.DataModels.Armor)_context.Items.SingleOrDefault(w => w.ItemID == armor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AcceptQuest(int quest, string player)
        {
            var tempQuest = _context.Quests.SingleOrDefault(q => q.QuestID == quest);
            var questrewarditemID = _context.Quests.Where(q => q.QuestID == quest).Select(q => q.RewardItem.ItemID);
            var qrID = questrewarditemID.FirstOrDefault();
            var rewardItem = _context.Items.SingleOrDefault(i => i.ItemID == qrID);
            tempQuest.RewardItem = rewardItem;
            var questCompItemID = _context.Quests.Where(q => q.QuestID == quest).Select(q => q.QuestCompletionItem.QuestCompletionItemID);
            var qcID = questCompItemID.FirstOrDefault();
            var questcompletionItem = _context.QuestCompletionItems.SingleOrDefault(qc => qc.QuestCompletionItemID == qcID);
            tempQuest.QuestCompletionItem = questcompletionItem;
            var questCompDetailID = _context.Quests.Where(q => q.QuestID == quest).Select(q => q.QuestCompletionItem.details.ItemID);
            var detailID = questCompDetailID.FirstOrDefault();
            var detailItem = _context.Items.SingleOrDefault(i => i.ItemID == detailID);
            tempQuest.QuestCompletionItem.details = detailItem;
            var tempPC = _context.PlayerCharacters.SingleOrDefault(p => p.CharacterName == player);
            Models.DataModels.Quest newDMQ = tempQuest;

            Models.DataModels.QuestLog newQuestLog = new Models.DataModels.QuestLog()
            {
                Player = tempPC,
                CollectedQuest = newDMQ,
                Completed = false
            };
            await _context.QuestLogs.AddAsync(newQuestLog);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //method for datamodel to viewmodel conversion
        private Models.ViewModels.PlayerCharacter ConvertdmPCtovmPC(Models.DataModels.PlayerCharacter dmPlayer)
        {
            Models.ViewModels.PlayerCharacter vmPlayer = new Models.ViewModels.PlayerCharacter()
            {
                CharacterName = dmPlayer.CharacterName,
                Gold = dmPlayer.Gold,
                ExperiencePoints = dmPlayer.ExperiencePoints,
                ExpNeededToLevel = dmPlayer.ExpNeededToLevel,
                Level = dmPlayer.Level,
                CurrentHitPoints = dmPlayer.CurrentHitPoints,
                MaximumHitPoints = dmPlayer.MaximumHitPoints,
                CurrentLocationID = ConvertdmLocationTovmLocation(dmPlayer.CurrentLocationID),
                CurrentWeapon = ConvertdmWeaponTovmWeapon(dmPlayer.CurrentWeapon),
                CurrentArmor = ConvertdmArmorTovmArmor(dmPlayer.CurrentArmor)
            };
            return vmPlayer;
        }
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
                LocationToNorth = dmLocation.LocationToNorth,
                LocationToSouth = dmLocation.LocationToSouth,
                LocationToEast = dmLocation.LocationToEast,
                LocationToWest = dmLocation.LocationToWest
            };
            if (dmLocation.ItemRequiredToEnter != null) {vmLocation.ItemRequiredToEnter = ConvertdmItemtovmItem(dmLocation.ItemRequiredToEnter);}
            if (dmLocation.QuestAvailableHere != null) {vmLocation.QuestAvailableHere = ConvertdmQuesttovmQuest(dmLocation.QuestAvailableHere);}
            if (dmLocation.EnemyFightHere != null) { vmLocation.EnemyFightHere = ConvertdmEnemytovmEnemy(dmLocation.EnemyFightHere);}
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

        private Models.ViewModels.QuestLog ConvertdmQLogTovmQLog(Models.DataModels.QuestLog dmQLog)
        {
            Models.ViewModels.QuestLog vmQLog = new Models.ViewModels.QuestLog()
            {
                QuestLogID = dmQLog.QuestLogID,
                Player = ConvertdmPCtovmPC(dmQLog.Player),
                CollectedQuest = ConvertdmQuesttovmQuest(dmQLog.CollectedQuest),
                Completed = dmQLog.Completed

            };
            return vmQLog;
        }

        private Models.ViewModels.Inventory ConvertdmInventoryTovmInventory(Models.DataModels.Inventory dmInventory)
        {
            Models.ViewModels.Inventory vmInventory = new Models.ViewModels.Inventory()
            {
                InventoryID = dmInventory.InventoryID,
                PlayerCharacter = ConvertdmPCtovmPC(dmInventory.PlayerCharacter),
                Detail = ConvertdmItemtovmItem(dmInventory.Detail),
                Quantity = dmInventory.Quantity
            };
            return vmInventory;
        }

        // convert View Model to Data Model
        private Models.DataModels.Location ConvertvmLocationTodmLocation(Models.ViewModels.Location vmLocation)
        {
            Models.DataModels.Location dmLocation = new Models.DataModels.Location()
            {
                LocationID = vmLocation.LocationID,
                LocationName = vmLocation.LocationName,
                LocationDescription = vmLocation.LocationDescription,
                LocationToNorth = vmLocation.LocationToNorth,
                LocationToSouth = vmLocation.LocationToSouth,
                LocationToEast = vmLocation.LocationToEast,
                LocationToWest = vmLocation.LocationToWest
            };
            if(vmLocation.ItemRequiredToEnter != null) { dmLocation.ItemRequiredToEnter = ConvertvmItemtodmItem(vmLocation.ItemRequiredToEnter);}
            if(vmLocation.QuestAvailableHere != null) { dmLocation.QuestAvailableHere = ConvertvmQuestTodmQuest(vmLocation.QuestAvailableHere);}
            if(vmLocation.EnemyFightHere != null) { dmLocation.EnemyFightHere = ConvertvmEnemytodmEnemy(vmLocation.EnemyFightHere);}
            return dmLocation;
        }

        private Models.DataModels.Item ConvertvmItemtodmItem(Models.ViewModels.Item vmItem)
        {
            Models.DataModels.Item dmItem = new Models.DataModels.Item()
            {
                ItemID = vmItem.ItemID,
                Name = vmItem.Name,
                PluralName = vmItem.PluralName
            };
            return dmItem;
        }

        private Models.DataModels.Quest ConvertvmQuestTodmQuest(Models.ViewModels.Quest vmQuest)
        {
            Models.DataModels.Quest dmQuest = new Models.DataModels.Quest()
            {
                QuestID = vmQuest.QuestID,
                QuestName = vmQuest.QuestName,
                QuestDescription = vmQuest.QuestDescription,
                RewardExperiencePoints = vmQuest.RewardExperiencePoints,
                RewardGold = vmQuest.RewardGold,
                RewardItem = ConvertvmItemtodmItem(vmQuest.RewardItem),
                QuestCompletionItem = ConvertvmQCItodmQCI(vmQuest.QuestCompletionItem)

            };
            return dmQuest;
        }

        private Models.DataModels.QuestCompletionItem ConvertvmQCItodmQCI(Models.ViewModels.QuestCompletionItem vmQCI)
        {
            Models.DataModels.QuestCompletionItem dmQCI = new Models.DataModels.QuestCompletionItem()
            {
                QuestCompletionItemID = vmQCI.QuestCompletionItemID,
                details = ConvertvmItemtodmItem(vmQCI.details),
                quantity = vmQCI.quantity
            };
            return dmQCI;
        }

        private Models.DataModels.Enemy ConvertvmEnemytodmEnemy(Models.ViewModels.Enemy vmEnemy)
        {
            List<Models.DataModels.LootItem> lootTable = new List<Models.DataModels.LootItem>();
            foreach(var lootItem in vmEnemy.LootTable)
            {
                lootTable.Add(ConvertvmLItodmLI(lootItem));
            }
            Models.DataModels.Enemy dmEnemy = new Models.DataModels.Enemy()
            {
                EnemyID = vmEnemy.EnemyID,
                EnemyName = vmEnemy.EnemyName,
                MinimumDamage =vmEnemy.MinimumDamage,
                MaximumDamage = vmEnemy.MaximumDamage,
                RewardExperience = vmEnemy.RewardExperience,
                RewardGold = vmEnemy.RewardGold,
            };
            return dmEnemy;
        }

        private Models.DataModels.LootItem ConvertvmLItodmLI(Models.ViewModels.LootItem vmLI)
        {
            Models.DataModels.LootItem dmLI = new Models.DataModels.LootItem()
            {
                LootItemID = vmLI.LootItemID,
                Details = ConvertvmItemtodmItem(vmLI.Details),
                DropRate = vmLI.DropRate,
                MinQuantity = vmLI.MinQuantity,
                MaxQuantity = vmLI.MaxQuantity
            };
            return dmLI;
        }
    }
}
