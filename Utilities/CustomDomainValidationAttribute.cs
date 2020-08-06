using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.Utilities
{
    public class CustomDomainValidationAttribute : ValidationAttribute
    {
        private readonly string _customDomain;

        public CustomDomainValidationAttribute(string customDomain)
        {
            _customDomain = customDomain;
        }
        public override bool IsValid(object value)
        {
            string[] strings = value.ToString().Split('@');
            return strings[1].ToUpper() == _customDomain.ToUpper();
        }
    }
}
