using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models.Zenith.CustomValidation
{
    class IsSameDay : ValidationAttribute
    {
        public string EventFromProperty { get; private set; }

        public IsSameDay(string EventFrom) : base("The event cannot last more than one day.")
        {
            this.EventFromProperty = EventFrom;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime EventFrom = (DateTime)validationContext.ObjectType.GetProperty(this.EventFromProperty)
                                                             .GetValue(validationContext.ObjectInstance, null);
            DateTime EventTo = (DateTime)value;
            if (value != null)
            {
                if (EventTo.Date != EventFrom.Date)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
