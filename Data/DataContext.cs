using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Data
{
    public class DataContext:DbContext{
        public DbSet<Student>Students => Set<Student>();
        public DbSet<Course>Courses => Set<Course>();
        public DbSet<CourseRegister>CourseRegisters => Set<CourseRegister>();
    }
}