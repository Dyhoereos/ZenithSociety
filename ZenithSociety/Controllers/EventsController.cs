using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using ZenithSociety.Models.Zenith;

namespace ZenithSociety.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        [Authorize(Roles ="Admin, Member")]
        public ActionResult Index()
        {
            var events = db.Events.Include(@a => @a.Activity).Include(@a => @a.ApplicationUser);
            return View(events.ToList());
        }

        // admin GET: Events
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            var events = db.Events.Include(@a => @a.Activity).Include(@a => @a.ApplicationUser);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            Activity @activity = db.Activities.Find(@event.ActivityId);
            ViewBag.ActDesc = @activity.ActivityDesc;

            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDesc");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "EventId,EventFrom,EventTo,UserId,CreationDate,ActivityId,IsActive")] Event @event)
        {
            if (ModelState.IsValid)
            {

                @event.CreationDate = DateTime.Now;

                var store = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(store);
                @event.ApplicationUser = userManager.FindByNameAsync(User.Identity.Name).Result;

                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDesc", @event.ActivityId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", @event.UserId);
            return View(@event);
        }

        // GET: Events/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDesc", @event.ActivityId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", @event.UserId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "EventId,EventFrom,EventTo,UserId,ActivityId,CreationDate,IsActive")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.ApplicationUser = System.Web.HttpContext.Current.
                    GetOwinContext().GetUserManager<ApplicationUserManager>().
                    FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                @event.CreationDate = DateTime.Now;
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            //ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDesc", @event.ActivityId);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", @event.UserId);
            return View(@event);
        }

        // GET: Events/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            Activity @activity = db.Activities.Find(@event.ActivityId);
            ViewBag.ActDesc = @activity.ActivityDesc;
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
