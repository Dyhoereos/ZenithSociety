using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebsite.Models.CustomValidation;

namespace ZenithWebsite.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "From Date & Time")]
        public DateTime EventFrom { get; set; }

        [Display(Name = "To Date & Time")]
        [IsDateAfter("EventFrom")]
        [IsSameDay("EventFrom")]
        public DateTime EventTo { get; set; }

        [Display(Name = "Creator")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Activity")]
        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public Boolean IsActive { get; set; }
    }
}
