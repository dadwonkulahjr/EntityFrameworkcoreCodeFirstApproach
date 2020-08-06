using EntityFrameworkcoreCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.ViewModels
{
    public class HomeDetailViewModel
    {
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }
    }
}
