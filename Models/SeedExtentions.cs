using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.Models
{
    public static class SeedExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
              new Employee()
              { 
                  Id = 1, Fullname = "John Brown",
                  Salary = 10000, Email = "john@yahoo.com",
                  Department = Department.Management 
              },
              new Employee()
              {
                  Id = 2,
                  Fullname = "Mary Smith",
                  Salary = 15000,
                  Email = "mary@outlook.com",
                  Department = Department.IT
              });
        }
    }
}
