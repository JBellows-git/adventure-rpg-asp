using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureProject.Data;
using AdventureProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AdventureProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> AllUsers()
        {
            
            List<Models.ViewModels.UserView> userViews = new List<Models.ViewModels.UserView>();            
            var users = _userManager.Users.ToList();
            var players = _context.PlayerCharacters.ToList();
            var roles = _roleManager.Roles.ToList();
            foreach (var u in users)
            {
                Models.ViewModels.UserView temp = new Models.ViewModels.UserView();
                foreach(var p in players)
                {
                    if(p.UserID == u.Id)
                    {
                        temp.Username = u.UserName;
                        temp.CharacterName = p.CharacterName;
                        var roleList = await _userManager.GetRolesAsync(u);
                        var roleTemp = String.Join(", ", roleList);
                        temp.Roles = roleTemp;
                        userViews.Add(temp);
                    }
                    
                    
                }
            }
            ViewBag.Users = users;
            ViewBag.Roles = roles;
            
            return View(userViews);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            var name = collection["RoleName"];
            try
            {
                await _roleManager.CreateAsync(new IdentityRole(name));
                ViewBag.message = "Creation Successful";                
                
            } catch {
                ViewBag.message = "Creation Failed";
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AssignRole(string role, string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            try
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            catch { }
            return RedirectToAction("AllUsers");
        }

    }

    
}
