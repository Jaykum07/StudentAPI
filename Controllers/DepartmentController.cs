using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;


namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _departmentService.GetDepartments();
            return Ok(departments);
        }


        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            var addedDepartment = _departmentService.AddDepartment(department);
            if(addedDepartment == null)
            {
                return BadRequest("Failed to add department.");
            }
            return CreatedAtAction(nameof(GetDepartmentById), new { id = addedDepartment.Id }, addedDepartment);
        }
    }
}