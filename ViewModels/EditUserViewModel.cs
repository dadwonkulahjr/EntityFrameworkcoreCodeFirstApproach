using EntityFrameworkcoreCodeFirstApproach.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Cannt exceed 50 characters.")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [CustomDomainValidation("tuseTheProgrammer.com", ErrorMessage = "Email domain must be tuseTheProgrammer")]
        public string Email { get; set; }
        public string City { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
