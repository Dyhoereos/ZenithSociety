using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ZenithDataLib.Models;

namespace ZenithSociety.Models.Zenith
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public DateTime EventFrom { get; set; }

        public DateTime EventTo { get; set; }

        [Display(Name = "Creator")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Activity")]
        public int ActivityId { get; set; }

        public Activity Activity { get; set; }

        public DateTime CreationDate { get; set; }

        public Boolean IsActive { get; set; }
    }
}