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
    public class CharacterController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        
        public CharacterController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            //come back and add if statement to redirect to game if character already exists
            var user = await _userManager.GetUserAsync(User);
            bool hasCharacter = _context.PlayerCharacters.Any(p => p.UserID == user.Id);
            if (hasCharacter)
            {
                return RedirectToAction("Index", "Game");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacterAsync(AdventureProject.Models.ViewModels.PlayerCharacter playerCharacter)
        {
            
            bool existingName = _context.PlayerCharacters.Any(p => p.CharacterName == playerCharacter.CharacterName);
            if (existingName)
            {
                ViewBag.message = "That name has already been taken.";
                
            } else
            {
                Models.DataModels.PlayerCharacter newPlayer = CreateNewPlayer(playerCharacter);                
                await _context.PlayerCharacters.AddAsync(newPlayer);                
                await _context.SaveChangesAsync();
                Models.DataModels.Inventory weapon = new Models.DataModels.Inventory()
                {
                    PlayerCharacter = _context.PlayerCharacters.SingleOrDefault(p => p.CharacterName == newPlayer.CharacterName),
                    Detail = newPlayer.CurrentWeapon,
                    Quantity = 1
                };
                Models.DataModels.Inventory armor = new Models.DataModels.Inventory()
                {
                    PlayerCharacter = _context.PlayerCharacters.SingleOrDefault(p => p.CharacterName == newPlayer.CharacterName),
                    Detail = newPlayer.CurrentArmor,
                    Quantity = 1
                };
                await _context.Inventories.AddAsync(weapon);
                await _context.Inventories.AddAsync(armor);
                await _context.SaveChangesAsync();
            }

            return View("Index");
        }



        private Models.DataModels.PlayerCharacter CreateNewPlayer(Models.ViewModels.PlayerCharacter playerCharacter)
        {
            var user = _userManager.GetUserId(User);
            
            Models.DataModels.Weapon beginnerWeapon = (Models.DataModels.Weapon)_context.Items.SingleOrDefault(w => w.Name == "Rusty Sword");
            Models.DataModels.Armor beginnerArmor = (Models.DataModels.Armor)_context.Items.SingleOrDefault(a => a.Name == "Cloth Armor");
            Models.DataModels.Location beginningLocation = (Models.DataModels.Location)_context.Locations.SingleOrDefault(l => l.LocationName == "Home");
            Models.DataModels.PlayerCharacter dmPlayer = new Models.DataModels.PlayerCharacter()
            {
                UserID = user,
                CharacterName = playerCharacter.CharacterName,                
                CurrentHitPoints = 10,
                MaximumHitPoints = 10,
                CurrentWeapon = beginnerWeapon,
                CurrentArmor = beginnerArmor,
                ExpNeededToLevel = 100,
                Level = 1,
                CurrentLocationID = beginningLocation                
            };
            return dmPlayer;
                
        }
    }
}
