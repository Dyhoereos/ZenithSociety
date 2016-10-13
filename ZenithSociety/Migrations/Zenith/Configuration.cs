namespace ZenithSociety.Migrations.Zenith
{
    using Models;
    using Models.Zenith;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithSociety.Models.ZenithContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Zenith";
        }

        protected override void Seed(ZenithSociety.Models.ZenithContext context)
        {
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
            List<Activity> activities = new List<Activity>() {
                new Activity
                {
                    ActivityDesc = "Senior’s Golf Tournament",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Leadership General Assembly Meeting",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Youth Bowling Tournament",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Young ladies cooking lessons",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Youth craft lessons",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Youth choir practice",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Lunch",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Pancake Breakfast",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Swimming Lessons for the youth",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Swimming Exercise for parents",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Bingo Tournament",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "BBQ Lunch",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
                new Activity
                {
                    ActivityDesc = "Garage Sale",
                    CreationDate = Convert.ToDateTime("2016/09/10")
                },
            };
            return activities;
        }

        public static List<Event>  getEvents(ZenithContext db)
        {
            List<Event> events = new List<Event>()
            {
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/09/27 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/09/27 10:30 am"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Senior’s Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/09/28 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/09/28 10:30 am"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/09/30 5:30 pm"),
                    EventTo = Convert.ToDateTime("2016/09/30 7:15 pm"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/09/30 7:00 pm"),
                    EventTo = Convert.ToDateTime("2016/09/30 8:00 pm"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/01 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/01 10:30 am"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/01 10:30 pm"),
                    EventTo = Convert.ToDateTime("2016/10/01 12:30 pm"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/01 12:30 pm"),
                    EventTo = Convert.ToDateTime("2016/10/01 10:30 am"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/02 7:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 8:30 am"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/02 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 10:30 am"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/02 8:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 10:30 am"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/02 10:30 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 12:30 pm"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/02 12:00 am"),
                    EventTo = Convert.ToDateTime("2016/10/02 1:00 pm"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = Convert.ToDateTime("2016/10/02 1:00 pm"),
                    EventTo = Convert.ToDateTime("2016/10/02 6:00 pm"),
                    Creator = "a",
                    Activity = db.Activities.First(a => a.ActivityDesc == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                },
            };
            return events;
        }

    }
}
