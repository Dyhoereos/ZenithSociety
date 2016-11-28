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
            if (!db.Activities.Any())
            {
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Senior’s Golf Tournament",
                    CreationDate = Convert.ToDateTime("2016/11/20")
                });

                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Leadership General Assembly Meeting",
                    CreationDate = Convert.ToDateTime("2016/12/1")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Youth Bowling Tournament",
                    CreationDate = Convert.ToDateTime("2016/12/2")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Young ladies cooking lessons",
                    CreationDate = Convert.ToDateTime("2016/12/3")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Youth craft lessons",
                    CreationDate = Convert.ToDateTime("2016/12/4")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Youth choir practice",
                    CreationDate = Convert.ToDateTime("2016/11/22")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Lunch",
                    CreationDate = Convert.ToDateTime("2016/11/23")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Pancake Breakfast",
                    CreationDate = Convert.ToDateTime("2016/11/13")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Swimming Lessons for the youth",
                    CreationDate = Convert.ToDateTime("2016/11/14")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Swimming Exercise for parents",
                    CreationDate = Convert.ToDateTime("2016/11/21")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Bingo Tournament",
                    CreationDate = Convert.ToDateTime("2016/11/24")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "BBQ Lunch",
                    CreationDate = Convert.ToDateTime("2016/11/25")
                });
                db.Activities.Add(new Activity
                {
                    //ActivityId = ++counter,
                    ActivityDesc = "Garage Sale",
                    CreationDate = Convert.ToDateTime("2016/11/10")
                });

                db.SaveChanges();
            }
        }

        public static void addEvents(ApplicationDbContext db)
        {
            if (!db.Events.Any())
            {
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/14 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/14 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/15 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/15 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/16 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/11/16 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/17 7:00 pm"),
                    EventTo = Convert.ToDateTime("2016/11/17 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/18 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/18 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/19 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/19 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/20 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/11/20 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/21 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/21 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/22 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/22 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/23 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/23 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/24 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/24 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/25 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/11/25 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/26 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/11/26 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/27 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/27 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/28 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/11/28 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/29 6:00 pm"),
                    EventTo = Convert.ToDateTime("2016/11/29 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/30 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/30 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/01 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/01 12:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/02 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/12/02 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/03 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/03 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/04 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/04 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/05 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/05 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/06 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/12/06 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/07 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/12/07 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/08 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/08 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/09 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/09 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/10 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/12/10 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/11 7:00 pm"),
                    EventTo = Convert.ToDateTime("2016/12/11 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/12 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/12 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/13 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/13 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/14 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/12/14 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/15 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/12/15 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/21 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/21 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/22 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/22 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/23 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/11/23 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/12/1 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/12/1 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/21 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/11/21 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    //EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/11/30 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/11/30 6:00 pm"),
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
