using StudentAPI.Models;

namespace StudentAPI.Services
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        Department? GetDepartmentById(int id);
        Department? AddDepartment(Department department);
    }
}