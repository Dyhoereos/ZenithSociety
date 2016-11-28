using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using ZenithWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ZenithWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventsController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, ILogger<EventsController> logger, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
