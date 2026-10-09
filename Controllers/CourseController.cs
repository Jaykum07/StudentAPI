using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;


namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _courseService.GetCourses();
            return Ok(courses);
        }


        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            var addedCourse = _courseService.AddCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = addedCourse.Id }, addedCourse);
        }


    }
}