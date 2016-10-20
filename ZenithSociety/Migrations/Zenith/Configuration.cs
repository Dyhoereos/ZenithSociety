namespace ZenithSociety.Migrations.Zenith
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Zenith;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Zenith";
        }

        protected override void Seed(ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "a";
                user.Email = "a@a.a";

                string userPWD = "P@$$w0rd";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Member"))
            {
                var role = new IdentityRole();
                role.Name = "Member";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "m";
                user.Email = "m@m.m";

                string userPWD = "P@$$w0rd";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Member");
                }
            }

            context.Activities.AddOrUpdate(
                a => a.ActivityId,
                getActivities().ToArray()
            );
            context.SaveChanges();

            context.Events.AddOrUpdate(
                e => e.EventId,
                getEvents(context).ToArray()
            );
            context.SaveChanges();
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
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Leadership General Assembly Meeting",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Youth Bowling Tournament",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Young ladies cooking lessons",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Youth craft lessons",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Youth choir practice",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Lunch",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Pancake Breakfast",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Swimming Lessons for the youth",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Swimming Exercise for parents",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Bingo Tournament",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "BBQ Lunch",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityId = ++counter,
                    ActivityDesc = "Garage Sale",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
            };
            return activities;
        }
        
        public static List<Event>  getEvents(ApplicationDbContext db)
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
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/09/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/09/28 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/09/30 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/09/30 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/09/30 7:00 pm"),
                    EventTo = Convert.ToDateTime("2016/09/30 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/01 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/01 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/01 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/01 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/01 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/01 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/02 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/02 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/02 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/18 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/18 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/24 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/10/24 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/23 6:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/23 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/25 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/25 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/17 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/17 12:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/20 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/20 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/27 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/27 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/24 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/24 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/28 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/21 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/21 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/22 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/22 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/28 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/29 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/29 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/29 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/10/29 7:15 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/31 7:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/31 8:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/28 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/29 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/29 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/27 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/27 1:30 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/24 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/24 8:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/23 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/23 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/25 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/25 10:30 am"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/26 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/26 12:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/20 12:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/20 1:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/20 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/20 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventId = ++counter,
                    EventFrom = Convert.ToDateTime("2016/10/30 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/30 6:00 pm"),
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                }
            };
            return events;
        }
        
    }
}
