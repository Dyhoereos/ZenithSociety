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
            int numRoles = _context.UserRoles.Count();
            _logger.LogCritical(numRoles.ToString());
            // id, list of users
            var data = new  Dictionary<string, List<string>>();

            foreach (var role in _context.UserRoles)
            {
                
                var curRole = await _roleManager.FindByIdAsync(role.RoleId);
                
                _logger.LogCritical(curRole.Name);
                _logger.LogCritical(curRole.Users.Count().ToString());


                //foreach (var user in role.Users.ToList())
                //{
                //    _logger.LogCritical(role.Name.ToString());
                //    _logger.LogCritical(user.UserId);
                //}
            }

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