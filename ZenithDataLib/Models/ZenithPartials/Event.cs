using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithSociety.Models.Zenith
{
    [MetadataType(typeof(EventMetaData))]
    public partial class Event { }
    
    public class EventMetaData{

        [Display(Name = "From Date")]
        [Required]
        public DateTime EventFrom { get; set; }

        [Display(Name = "To Date")]
        [Required]
        public DateTime EventTo { get; set; }

        [Display(Name = "Activity")]
        public int ActivityId { get; set; }

        [Display(Name = "Is Active")]
        public Boolean IsActive { get; set; }
    }
}
