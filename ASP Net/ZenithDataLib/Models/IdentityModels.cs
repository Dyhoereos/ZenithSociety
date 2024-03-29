﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ZenithSociety.Models.Zenith;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZenithDataLib.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Creator")]
        [MaxLength(20, ErrorMessage = "{0} must be less than {1} characters")]
        public override string UserName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = "{0} must be less than {1} characters")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(20, ErrorMessage = "{0} must be less than {1} characters")]
        public string FirstName { get; set; }
        
        public virtual List<Event> Event { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Event> Events { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}