using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Display(Name = "Activity")]
        [Required]
        [MaxLength(70, ErrorMessage = "The {0} must be less than {1} characters long.")]
        public String ActivityDesc { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreationDate { get; set; }

        public List<Event> Events { get; set; }
    }
}
