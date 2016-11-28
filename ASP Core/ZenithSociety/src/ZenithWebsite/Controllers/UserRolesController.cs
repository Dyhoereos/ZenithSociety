using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ZenithWebsite.Models;
using ZenithWebsite.Models.Zenith;

namespace ZenithWebsite.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRolesController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(ApplicationDbContext context, 
                                   RoleManager<IdentityRole> roleManager, 
                                   ILogger<UserRolesController> logger,  
                                   UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {
            // id, list of users
            var data = new Dictionary<string, List<string>>();
            // dictionary of user/role id to name
            var idName = new Dictionary<string, string>();

            var roleList = _roleManager.Roles;
            foreach (var role in roleList)
            {
                idName.Add(role.Id, role.Name);
                data.Add(role.Id, new List<string>());
            }

            foreach (var role in _context.UserRoles)
            {
                var users = new List<string>();
                var curRole = await _roleManager.FindByIdAsync(role.RoleId);
                
                // Users are not populated all at once, so loop through to get new users
                foreach(var user in curRole.Users)
                {
                    users.Add(user.UserId);

                    // add to name/id dictionary
                    var curUser = await _userManager.FindByIdAsync(user.UserId);
                    if (!idName.ContainsKey(curUser.Id))
                    {
                        idName.Add(curUser.Id, curUser.UserName);
                    }
                }

                // re-add to data dictionary
                data[curRole.Id] = users;
            }

            ViewData["userRoles"] = data;
            ViewData["idName"] = idName;

            return View();
        }

        // GET: UserRoles/AddUser
        public ActionResult AddUser(string id)
        {
            var userDict = new Dictionary<string, string>();

            var users = _userManager.Users;
            foreach (var user in users)
            {
                userDict.Add(user.Id, user.UserName);
            }

            ViewData["Role"] = id;
            ViewData["Users"] = userDict;

            return View();
        }

        // POST: UserRoles/AddUser
        public async Task<IActionResult> AddConfirmed(string id)
        {
            string[] roleUser = id.Split('=');
            
            var user = await _userManager.FindByIdAsync(roleUser[0]);
            var role = await _roleManager.FindByIdAsync(roleUser[1]);            

            if (user.UserName == "a" && role.Name == "admin")
                return RedirectToAction("Index");

            IdentityResult x = await _userManager.AddToRoleAsync(user, role.Name);

            return RedirectToAction("Index");
        }

        // GET: UserRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            string[] roleUser = id.Split('=');
            _logger.LogCritical(id);

            var role = await _roleManager.FindByIdAsync(roleUser[0]);
            var user = await _userManager.FindByIdAsync(roleUser[1]);

            ViewData["Role"] = role.Name;
            ViewData["User"] = user.UserName;

            return View();
        }

        // POST: UserRoles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IFormCollection collection)
        {
            string roleId = HttpContext.Request.Form["role"];
            string userId = HttpContext.Request.Form["user"];

            var role = await _roleManager.FindByNameAsync(roleId);
            
            ApplicationUser user = await _userManager.FindByNameAsync(userId);


            await _userManager.RemoveFromRoleAsync(user, role.Name);

            return RedirectToAction("Index");

        }
    }
}