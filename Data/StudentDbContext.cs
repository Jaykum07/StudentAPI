using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Data
{
	public class StudentDbContext : DbContext
	{
		public DbSet<Student> Students { get; set; }

		public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
		{

		}
	}

}