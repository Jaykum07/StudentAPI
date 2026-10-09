using StudentAPI.Models;
namespace StudentAPI.Services
{
    public interface IStudentService
    {   
        List<Student> GetStudents();
        Student? GetStudentById(int id);
        Student AddStudent(Student student);
        Student? UpdateStudent(int id, Student student);
        Student? DeleteStudent(int id);
        Task<List<Student>> GetStudentsByDepartmentIdAsync(int departmentId);
    }

}
