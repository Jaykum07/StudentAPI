using StudentAPI.Models;
namespace StudentAPI.Services

{
    public class StudentService: IStudentService
    {
        private List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Marks = 85 },
            new Student { Id = 2, Name = "Jane Smith", Marks = 92 },
            new Student { Id = 3, Name = "Alice Johnson", Marks = 78 }
        };

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student? GetStudentById(int id)
        {
            var stu = students.FirstOrDefault(stu => stu.Id == id);

            return stu;

        }

        public Student AddStudent(Student student)
        {
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);
            return student;
        }

        public Student? UpdateStudent(int id, Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if(existingStudent == null)
            {
                //throw new Exception($"Student with Id {id} not found.");
                return null;
            }
            else
            {
                existingStudent.Name = student.Name;
                existingStudent.Marks = student.Marks;
            }
            

            return existingStudent;
        }

        public Student? DeleteStudent(int id)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return null;
            }
            else
            {
                students.Remove(existingStudent);
                return existingStudent;
            }
        }
    }
}
