using StudentAPI.Models;
using StudentAPI.Data;
namespace StudentAPI.Services

{
    public class StudentService: IStudentService
    {
        
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            if (_context.Students != null)
            {
                return _context.Students.ToList();
            }

            return new List<Student>();
        }

        public Student? GetStudentById(int id)
        {
            var stu = _context.Students.FirstOrDefault(stu => stu.Id == id);

            return stu;

        }

        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student? UpdateStudent(int id, Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                //throw new Exception($"Student with Id {id} not found.");
                return null;
            }
            else
            {
                existingStudent.Name = student.Name;
                existingStudent.Marks = student.Marks;
            }

            _context.SaveChanges();

            return existingStudent;
        }

        public Student? DeleteStudent(int id)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return null;
            }
            else
            {
                _context.Students.Remove(existingStudent);
                _context.SaveChanges();
                return existingStudent;
            }
        }
    }
}
