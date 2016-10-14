using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZenithSociety.Models.Zenith
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        public String ActivityDesc { get; set; }

        [Timestamp]
        public DateTime CreationDate { get; set; }

        public List<Event> Events { get; set; }
    }
}