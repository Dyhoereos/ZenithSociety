using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ZenithDataLib.Models;
using ZenithSociety.Models.Zenith;

namespace ZenithSociety.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            //determine first and last dates of week
            DayOfWeek firstWeekDay = DayOfWeek.Monday;
            DateTime startDateOfWeek = DateTime.Now.Date;
            while (startDateOfWeek.DayOfWeek != firstWeekDay)
            {
                startDateOfWeek = startDateOfWeek.AddDays(-1d);
            }
            DateTime endDateOfWeek = startDateOfWeek.AddDays(7d);

            ViewBag.StartendDates = new DateTime[] 
            { startDateOfWeek, endDateOfWeek.AddDays(-1d) };

            //get list of events that are from the current week and is active
            var events = db.Events.Include(@a => @a.Activity)
                                  .Include(@a => @a.ApplicationUser)
                                  .Where(a => a.EventFrom >= startDateOfWeek)
                                  .Where(a => a.EventFrom < endDateOfWeek)
                                  .Where(a => a.IsActive == true)
                                  .OrderBy(item => item.EventFrom)
                                  .ToList();

            return View(events);
        }

        // admin GET: Events
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            var events = db.Events.Include(@a => @a.Activity)
                                  .Include(@a => @a.ApplicationUser)
                                  .OrderBy(item => item.EventFrom)
                                  .ToList();
            return View(events);
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
            Activity activity = db.Activities.Find(@event.ActivityId);
            @event.Activity.ActivityDesc = activity.ActivityDesc;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "EventId,EventFrom,EventTo,UserId,CreationDate,ActivityId,IsActive")] Event @event)
        {
            if (ModelState.IsValid)
            {
                // set creation date to current datetime
                @event.CreationDate = DateTime.Now;

                // set creator to logged in user
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

            ViewBag.Activities = new SelectList(
                db.Activities
                .OrderBy(a => a.ActivityDesc),
                "ActivityId", "ActivityDesc", @event.ActivityId);


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
        public ActionResult Edit([Bind(Include = "EventId,UserId,EventTo,EventFrom,CreationDate,ActivityId,IsActive")] Event @event)
        {
            if (ModelState.IsValid)
            {
                //store back unchanged creation date and user id
                @event.CreationDate = db.Events.Find(@event.EventId).CreationDate;
                @event.UserId = db.Events.Find(@event.EventId).UserId;
                db.Events.AddOrUpdate(@event);
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
            Activity activity = db.Activities.Find(@event.ActivityId);
            @event.Activity.ActivityDesc = activity.ActivityDesc;

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
