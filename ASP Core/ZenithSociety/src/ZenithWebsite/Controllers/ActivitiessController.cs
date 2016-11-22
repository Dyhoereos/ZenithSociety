using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Data;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using ZenithWebsite.Models.Zenith;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebsite.Controllers
{
    public class ActivitiessController : Controller
    {
        private ApplicationDbContext db;
        public ActivitiessController(ApplicationDbContext context) {
            this.db = context;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: Activities
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(db.Activities.ToList());
        }

        // GET: Activities/Details/5
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] Activity activity)
        {
            activity.CreationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        // GET: Activities/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            return View(activity);
        }

        // POST: Activities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit([FromBody] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: Activities/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
