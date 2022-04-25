using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AdventureProject.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        
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

        public IActionResult AllUsers()
        {
            ViewBag.Users = _userManager.Users.ToList();
            ViewBag.Players = _context.PlayerCharacters.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            var name = collection["RoleName"];
            try
            {
                _roleManager.CreateAsync(new IdentityRole(name));
                ViewBag.message = "Creation Successful";
                
            } catch {
                ViewBag.message = "Creation Failed";
            }
            return View();
        }
    }

    
}
