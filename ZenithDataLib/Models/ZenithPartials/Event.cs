using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenithDataLib.Models;

namespace ZenithSociety.Models.Zenith
{
    [MetadataType(typeof(EventMetaData))]
    public partial class Event { }
    
    public class EventMetaData{

        [Display(Name = "Creator")]
        public string UserId { get; set; }

        [Display(Name = "From Date & Time")]
        public DateTime EventFrom { get; set; }

        [Display(Name = "To Date & Time")]
        public DateTime EventTo { get; set; }

        [Display(Name = "Activity")]
        public int ActivityId { get; set; }

        [Display(Name = "Is Active")]
        public Boolean IsActive { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreationDate { get; set; }
    }
}
