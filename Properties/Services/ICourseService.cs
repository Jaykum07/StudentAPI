using StudentAPI.Models;

namespace StudentAPI.Services
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        Course? GetCourseById(int id);
        Course AddCourse(Course course);
        //Course? UpdateCourse(int id, Course course);
        //Course? DeleteCourse(int id);
        //Task<List<Course>> GetCoursesByDepartmentIdAsync(int departmentId);
    }

}