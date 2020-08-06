using EntityFrameworkcoreCodeFirstApproach.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.ViewModels
{
    public class EmployeeCreateViewModel
    {
       
        [Required]
        [MaxLength(50, ErrorMessage = "Character length cannot exceed 50 characters")]
        public string Fullname { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        [Required]
        public Department? Department { get; set; }
        [Required]
        public decimal? Salary { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
