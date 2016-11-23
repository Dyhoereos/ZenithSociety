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
        public static async void Initialize(ApplicationDbContext db, IServiceProvider services)
        {

            await setRolesAndUsers(db, services);
            addActivities(db);
            addEvents(db);


        }

        public static async Task setRolesAndUsers(ApplicationDbContext context, IServiceProvider services)
        {
            using (var manager = services.GetRequiredService<RoleManager<IdentityRole>>())
            {

                if (!await manager.RoleExistsAsync("Admin"))
                {
                    var role = new IdentityRole { Name = "Admin" };
                    await manager.CreateAsync(role);
                }

                if (!await manager.RoleExistsAsync("Member"))
                {
                    var role = new IdentityRole { Name = "Member" };

                    await manager.CreateAsync(role);
                }
            }

            using (var manager = services.GetRequiredService<UserManager<ApplicationUser>>())
            {
                if (await manager.FindByNameAsync("a") == null)
                {
                    var user = new ApplicationUser {
                        UserName = "a",
                        Email = "a@a.a",
                        FirstName = "a",
                        LastName = "a",
                    };
                    
                    await manager.CreateAsync(user, "P@$$w0rd");
                    await manager.AddToRoleAsync(user, "Admin");

                }

                if (await manager.FindByNameAsync("m") == null)
                {
                    var user = new ApplicationUser {
                        UserName = "m",
                        Email = "m@m.m",
                        FirstName = "m",
                        LastName = "m"
                    };
                    
                    await manager.CreateAsync(user, "P@$$w0rd");
                    await manager.AddToRoleAsync(user, "Member");
                }
            }
            
        }

        public static void addActivities(ApplicationDbContext db)
        {
            int counter = 0;

            if (!db.Activities.Any())
            {
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Senior’s Golf Tournament",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });

                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Leadership General Assembly Meeting",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Youth Bowling Tournament",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Young ladies cooking lessons",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Youth craft lessons",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Youth choir practice",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Lunch",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Pancake Breakfast",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Swimming Lessons for the youth",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Swimming Exercise for parents",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Bingo Tournament",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "BBQ Lunch",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Garage Sale",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                });

                db.SaveChanges();
            }
        }

        public static void addEvents(ApplicationDbContext db)
        {
            int counter = 0;
            if (!db.Events.Any())
            {
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/09/27 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/09/27 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/09/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/09/28 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/09/30 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/09/30 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/09/30 7:00 pm"),
                    EventTo = Convert.ToDateTime("2016/09/30 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/01 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/01 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/01 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/01 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/01 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/01 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/02 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/02 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/18 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/18 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/24 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/10/24 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/23 6:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/23 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/25 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/25 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/17 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/17 12:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/20 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/20 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/27 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/27 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/24 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/24 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/28 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/21 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/21 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/22 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/22 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/28 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/29 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/29 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/29 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/10/29 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/31 7:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/31 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/28 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/29 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/29 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/27 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/27 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/24 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/24 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/23 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/23 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/25 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/25 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/26 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/26 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/20 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/20 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/20 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/20 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/30 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/30 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });

                db.SaveChanges();
            }
        }
    }
}
