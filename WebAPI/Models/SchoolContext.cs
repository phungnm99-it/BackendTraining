using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuider)
        {
            optionBuider.UseSqlServer(@"Server=DESKTOP-GISFHHL;Database=SchoolDB;Trusted_Connection=True;");
        }
    }
}
