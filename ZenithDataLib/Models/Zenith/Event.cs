using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZenithSociety.Models.Zenith
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public DateTime EventFrom { get; set; }

        public DateTime EventTo { get; set; }

        public String Creator { get; set; }

        [Display(Name = "Activity")]
        public int ActivityId { get; set; }

        public Activity Activity { get; set; }

        [Timestamp]
        public DateTime CreationDate { get; set; }

        public Boolean IsActive { get; set; }
    }
}