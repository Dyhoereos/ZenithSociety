﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebsite.Models.Zenith.CustomValidation
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
