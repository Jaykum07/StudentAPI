using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Data
{
	public class StudentDbContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<StudentProfile> StudentProfiles { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }
		public DbSet<Course> Courses { get; set; }

		public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Department>().HasMany(d => d.Students).WithOne(s => s.Department).HasForeignKey(s => s.DepartmentId);
            modelBuilder.Entity<StudentProfile>().HasOne(s => s.Student).WithOne(s => s.StudentProfile).HasForeignKey<StudentProfile>(sp => sp.StudentId);
            modelBuilder.Entity<Student>().HasMany(s => s.StudentCourses).WithOne(sc => sc.Student).HasForeignKey(sc => sc.StudentId);
            modelBuilder.Entity<Course>().HasMany(c => c.StudentCourses).WithOne(sc => sc.Course).HasForeignKey(sc => sc.CourseId);

        }

	}

}