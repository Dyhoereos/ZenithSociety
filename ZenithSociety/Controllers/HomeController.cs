using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using System.Data;
using System.Data.Entity;

namespace ZenithSociety.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //determine first and last dates of week
            DayOfWeek firstWeekDay = DayOfWeek.Monday;
            DateTime startDateOfWeek = DateTime.Now;
            System.Diagnostics.Debug.WriteLine(firstWeekDay.ToString());
            System.Diagnostics.Debug.WriteLine(startDateOfWeek.Date.ToString());
            while (startDateOfWeek.DayOfWeek != firstWeekDay)
            {
                startDateOfWeek = startDateOfWeek.AddDays(-1d);
                System.Diagnostics.Debug.WriteLine(startDateOfWeek.Date.ToString());
            }
            DateTime endDateOfWeek = startDateOfWeek.AddDays(7d);

            var events = db.Events.Include(@a => @a.Activity).Include(@a => @a.ApplicationUser)
                .Where(a => a.EventFrom >= startDateOfWeek)
                .Where(a => a.EventFrom <= endDateOfWeek);

            events = events.OrderBy(item => item.EventFrom);

            return View(events.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}