using StudentAPI.Models;
using StudentAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

        public async Task<List<Student>> GetStudentsByDepartmentIdAsync(int departmentId)
        {
            var students = await _context.Students.Include(s => s.Department)
                .Where(s => s.DepartmentId == departmentId)
                .ToListAsync();
            return students;
        }

    }
}
