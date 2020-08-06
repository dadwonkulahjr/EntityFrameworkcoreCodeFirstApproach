using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.Models
{
    public class SQLDbContext : IdentityDbContext<ApplicationUser>
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> dbContextOptions)
            :base(dbContextOptions)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }        
    }
}
