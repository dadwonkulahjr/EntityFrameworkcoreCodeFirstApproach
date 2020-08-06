using EntityFrameworkcoreCodeFirstApproach.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailValid", "Account")]
        [CustomDomainValidation("tuseTheProgrammer.com", ErrorMessage ="Email domain must be tuseTheProgrammer")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [DataType(DataType.Password)]
        [Display(Name ="Confirmed Password")]
        [Compare("Password", ErrorMessage ="Password and Confirmed Password do not match...")]
        public string ConfirmedPassword { get; set; }
        public string City { get; set; }
    }
}
