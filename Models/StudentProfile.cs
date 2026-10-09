namespace StudentAPI.Models
{
	public class StudentProfile
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int CurrentSem { get; set; }
		public bool IsAdult { get; set;}
		public Student? Student { get; set; }
	}
}