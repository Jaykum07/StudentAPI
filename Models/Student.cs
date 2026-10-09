namespace StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Marks { get; set; }
        public string Name { get; set; } = string.Empty;   
        public int Age { get; set; }
        public string ContactNo { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string EnrollmentNumber { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public StudentProfile? StudentProfile { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
