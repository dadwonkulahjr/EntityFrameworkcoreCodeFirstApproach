using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Character length cannot exceed 50 characters")]
        public string Fullname { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Office Email")]
        public string Email { get; set; }
        [Required]
        public Department? Department { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        public string PhotoPath { get; set; }
        
    }
}
