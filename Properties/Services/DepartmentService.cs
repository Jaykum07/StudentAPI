using StudentAPI.Models;
using StudentAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly StudentDbContext _context;
        public DepartmentService(StudentDbContext context)
        {
            _context = context;
        }
        public List<Department> GetDepartments()
        {
            if (_context.Departments != null)
            {
                return _context.Departments.ToList();
            }
            return new List<Department>();
        }
        public Department? GetDepartmentById(int id)
        {
            var department = _context.Departments.FirstOrDefault(dep => dep.Id == id);
            return department;
        }
        public Department? AddDepartment(Department department)
        {
            if (_context.Departments != null)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return department;
            }
            return null;
        }
    }
}