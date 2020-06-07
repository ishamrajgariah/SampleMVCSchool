using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using School.Entities;

namespace School.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
