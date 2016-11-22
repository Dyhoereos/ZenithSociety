using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebsite.Models;
using ZenithWebsite.Models.Zenith;

namespace ZenithWebsite.Data
{
    public class Seed
    {
        public static void Initialize(ApplicationDbContext db, IServiceProvider services)
        {
            //setRolesAndUsers(db, services);



            //if (!db.Students.Any())
            //{
            //    db.Students.Add(new Student
            //    {
            //        FirstName = "Bob",
            //        LastName = "Doe",
            //        School = "Engineering",
            //        StartDate = Convert.ToDateTime("2015/09/09")
            //    });

            //    db.SaveChanges();
            //}
        }

        public static async void setRolesAndUsers(ApplicationDbContext context, IServiceProvider services)
        {
            using (var manager = services.GetRequiredService<RoleManager<IdentityRole>>())
            {

                if (!context.Roles.Any(r => r.Name == "Admin"))
                {
                    var role = new IdentityRole { Name = "Admin" };
                    await manager.CreateAsync(role);
                }

                if (!context.Roles.Any(r => r.Name == "Member"))
                {
                    var role = new IdentityRole { Name = "Member" };

                    await manager.CreateAsync(role);
                }
            }

            using (var manager = services.GetRequiredService<UserManager<ApplicationUser>>())
            {
                if (!context.Users.Any(u => u.UserName == "a"))
                {
                    var user = new ApplicationUser { UserName = "a" };

                    await manager.CreateAsync(user, "P@$$w0rd");
                    await manager.AddToRoleAsync(user, "Admin");
                }

                if (!context.Users.Any(u => u.UserName == "m"))
                {
                    var user = new ApplicationUser { UserName = "m" };

                    await manager.CreateAsync(user, "P@$$w0rd");
                    await manager.AddToRoleAsync(user, "Member");
                }
            }
        }

        public static List<Activity> getActivities()
        {
            int counter = 0;
            List<Activity> activities = new List<Activity>() {
                    new Activity
                    {
                        ActivityId = ++counter,
                        ActivityDesc = "Senior’s Golf Tournament",
                        CreationDate = Convert.ToDateTime("2016/09/10")
                    }
                };
            return activities;
        }

        public static List<Event> getEvents(ApplicationDbContext db)
        {
            int counter = 0;
            List<Event> events = new List<Event>()
                {
                    new Event
                    {
                        EventId = ++counter,
                        EventFrom = Convert.ToDateTime("2016/09/27 8:30 am"),
                        EventTo = Convert.ToDateTime("2016/09/27 10:30 am"),
                        ApplicationUser = db.Users.First(a => a.UserName == "a"),
                        Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                        CreationDate = Convert.ToDateTime("2016/09/10"),
                        IsActive = true
                    }
                };
            return events;
        }
    }
}
