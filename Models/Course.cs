namespace StudentAPI.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int CountSubjects { get; set; }
		public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
	}
}