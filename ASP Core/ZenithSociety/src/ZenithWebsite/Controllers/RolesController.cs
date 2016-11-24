using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ZenithWebsite.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RolesController> _logger;

        public RolesController(RoleManager<IdentityRole> roleManager, ILogger<RolesController> logger)
        {
            _roleManager = roleManager;
            _logger  = logger;
        }

        // GET: Roles
        public IActionResult Index()
        {
            var roleList = new Dictionary<String, String>();

            foreach (var role in _roleManager.Roles.ToList())
            {
                roleList.Add(role.Name.ToString(), role.Id.ToString());
            }

            ViewData["RolesList"] = roleList;
            return View();
        }

        // GET: Roles/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(String role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var newRole = new IdentityRole { Name = role };
                await _roleManager.CreateAsync(newRole);
            }
            return RedirectToAction("Index");
        }

        //// GET: Roles/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Roles/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role.Name == "Admin" || role.Name == "Member")
                return View();

            try
            {
                await _roleManager.DeleteAsync(role);
                return View();
            }
            catch
            {
                return View();
            }

        }
    }
}