using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZenithSociety.Models.Zenith;

namespace ZenithSociety.Models
{
    public class ZenithContext : DbContext
    {
        public ZenithContext()
        : base("DefaultConnection")
        {
        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Event> Events { get; set; }        
    }
}