using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_with_Entity_Framework_Core.Models;

namespace Razor_Pages_with_Entity_Framework_Core.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Razor_Pages_with_Entity_Framework_Core.Models.Student> Students { get; set; }
        public DbSet<Razor_Pages_with_Entity_Framework_Core.Models.Enrollment> Enrollments { get; set; }
        public DbSet<Razor_Pages_with_Entity_Framework_Core.Models.Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        }
    }
}
