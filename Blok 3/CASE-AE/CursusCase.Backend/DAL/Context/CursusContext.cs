using CursusCase.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CursusCase.Backend.DAL.Context
{
    public class CursusContext : DbContext
    {
        public DbSet<CourseInstance> CourseInstances { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public CursusContext()
        { }

        public CursusContext(DbContextOptions<CursusContext> options)
            : base(options)
        {
        }
    }
}