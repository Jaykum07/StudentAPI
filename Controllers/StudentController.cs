using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {

            var students = _studentService.GetStudents();

            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);

            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult addStudent(Student student)   
        {


            var stu = _studentService.AddStudent(student);

            return CreatedAtAction(nameof(GetStudentById), new { id = stu.Id }, stu);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Student student)
        {
            var stu = _studentService.UpdateStudent(id, student) ;

            if (stu == null) return NotFound();

            return Ok(stu);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var stu = _studentService.DeleteStudent(id);

            if (stu == null) return NotFound();
           
             return NoContent();
        }

    }
}
