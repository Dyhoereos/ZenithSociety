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
            var idName = new Dictionary<string, string>();
            foreach (var role in _context.UserRoles)
            {
                List<string> users = new List<string>();
                var curRole = await _roleManager.FindByIdAsync(role.RoleId);

                if (!idName.ContainsKey(role.RoleId))
                    idName.Add(role.RoleId, curRole.Name);

                // create list of users in this role
                foreach(var u in curRole.Users)
                {
                    //_logger.LogCritical("adding user to list");
                    //_logger.LogCritical(u.UserId);
                    users.Add(u.UserId);

                    if (!data.ContainsKey(u.UserId))
                    {
                        var curUser = await _userManager.FindByIdAsync(u.UserId);
                        if (!idName.ContainsKey(u.UserId))
                            idName.Add(u.UserId, curUser.UserName);
                    }
                }

                // replace old list of users
                if (data.ContainsKey(role.RoleId))
                {
                    data[role.RoleId] = users;
                } else
                {
                    data.Add(role.RoleId, users);
                }
            }

            ViewData["userRoles"] = data;
            ViewData["idName"] = idName;
            

            return View();
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRoles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}