using StudentAPI.Models;
using StudentAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly StudentDbContext _context;
        public CourseService(StudentDbContext context)
        {
            _context = context;
        }
        public List<Course> GetCourses()
        {
            if (_context.Courses != null)
            {
                return _context.Courses.ToList();
            }
            return new List<Course>();
        }
        public Course? GetCourseById(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            return course;
        }

        public Course AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

    }
}