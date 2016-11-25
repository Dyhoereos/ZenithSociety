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
                
                // Users are not populated all at once, so loop through re-add to data dictionary
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

                data[curRole.Id] = users;
            }

            ViewData["userRoles"] = data;
            ViewData["idName"] = idName;

            return View();
        }

        // GET: UserRoles/Create
        public async Task<IActionResult> Create(string id)
        {
            IdentityUserRole<string> irole = null;

            foreach (var userRole in _context.UserRoles)
            {
                if (userRole.RoleId == id)
                {
                    irole = userRole;
                }
            }

            var role = await _roleManager.FindByIdAsync(irole.RoleId);

            var userList = _context.UserRoles;

            var usersInRole = new HashSet<IdentityUserRole<string>>(role.Users);

            _logger.LogCritical(role.Users.Count().ToString());

            var usersNotInRole = new Dictionary<string, string>();

            foreach (var user in userList)
            {
                if (usersInRole.Add(user))
                {
                    var curUser = await _userManager.FindByIdAsync(user.UserId);
                    usersNotInRole.Add(user.UserId, curUser.UserName);
                }
            }

            ViewData["Users"] = usersNotInRole;
            ViewData["Role"] = id;

            return View();
        }

        // POST: UserRoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            string roleId = HttpContext.Request.Form["role"];
            string userId = HttpContext.Request.Form["user"];

            var user = await _userManager.FindByIdAsync(userId);
            var role = await _roleManager.FindByIdAsync(roleId);

            await _userManager.AddToRoleAsync(user, role.Name);

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
        public async Task<IActionResult> Delete(string id, IFormCollection collection)
        {
            string roleId = HttpContext.Request.Form["role"];
            string userId = HttpContext.Request.Form["user"];

            var role = await _roleManager.FindByIdAsync(roleId);
            var user = await _userManager.FindByIdAsync(userId);

            _logger.LogCritical("role is " + role.Name);
            _logger.LogCritical("user is " + user.UserName);

            await _userManager.RemoveFromRoleAsync(user, role.Name);

            return View();
         
        }
    }
}