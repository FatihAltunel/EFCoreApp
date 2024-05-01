using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreApp.Data
{
    public class DataContext:DbContext{

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        public DbSet<Student>Students => Set<Student>();
        public DbSet<Course>Courses => Set<Course>();
        public DbSet<CourseRegister>CourseRegisters => Set<CourseRegister>();
    }
}