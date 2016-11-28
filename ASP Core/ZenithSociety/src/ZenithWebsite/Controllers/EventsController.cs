using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZenithWebsite.Data;
using ZenithWebsite.Models.Zenith;
using Microsoft.Extensions.Logging;
using ZenithWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ZenithWebsite.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventsController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(ApplicationDbContext context, ILogger<EventsController> logger, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            //determine first and last dates of week
            DayOfWeek firstWeekDay = DayOfWeek.Monday;
            DateTime startDateOfWeek = DateTime.Now.Date;
            while (startDateOfWeek.DayOfWeek != firstWeekDay)
            {
                startDateOfWeek = startDateOfWeek.AddDays(-1d);
            }
            DateTime endDateOfWeek = startDateOfWeek.AddDays(7d);

            ViewData["StartendDates"] = new DateTime[]
            { startDateOfWeek, endDateOfWeek.AddDays(-1d) };

            var applicationDbContext = _context.Events.Include(e => e.Activity)
                                                      .Include(e => e.ApplicationUser)
                                                      .Where(e => e.EventFrom >= startDateOfWeek)
                                                      .Where(e => e.EventFrom < endDateOfWeek)
                                                      .Where(e => e.IsActive == true)
                                                      .OrderBy(item => item.EventFrom);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin()
        {
            var applicationDbContext = _context.Events.Include(e => e.Activity)
                                                      .Include(e => e.ApplicationUser)
                                                      .OrderBy(item => item.EventFrom);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            Activity activity = await _context.Activities.SingleOrDefaultAsync(m => m.ActivityId == @event.ActivityId);
            @event.Activity.ActivityDesc = activity.ActivityDesc;

            ApplicationUser user = await _context.Users.SingleOrDefaultAsync(i => i.Id == @event.UserId);
            @event.ApplicationUser.UserName = user.UserName;

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityDesc");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("EventId,ActivityId,CreationDate,EventFrom,EventTo,IsActive,UserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                // set creation date to current datetime
                @event.CreationDate = DateTime.Now;

                // set creator to logged in user
                @event.ApplicationUser = await GetCurrentUserAsync();

                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityDesc", @event.ActivityId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", @event.UserId);
            return View(@event);
        }

        // GET: Events/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityDesc", @event.ActivityId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", @event.UserId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,ActivityId,CreationDate,EventFrom,EventTo,IsActive,UserId")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityDesc", @event.ActivityId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", @event.UserId);
            return View(@event);
        }

        // GET: Events/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
