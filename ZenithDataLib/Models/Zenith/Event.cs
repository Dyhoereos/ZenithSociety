using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZenithSociety.Models.Zenith
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime EventFrom { get; set; }
        public DateTime EventTo { get; set; }
        public String Creator { get; set; }
        public Activity Activity { get; set; }
        public String ActivityDesc { get; set; }
        public DateTime CreationDate { get; set; }
        public Boolean IsActive { get; set; }


    }
}