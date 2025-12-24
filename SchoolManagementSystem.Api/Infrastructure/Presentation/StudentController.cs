using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.student;
using Shared;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // =========================
        // CRUD
        // =========================

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await studentService.GetAllAsync();
            return Ok(students);
        }

        // GET: api/students/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await studentService.GetByIdAsync(id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await studentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // DELETE: api/students/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await studentService.DeleteAsync(id);

            if (!deleted)
                return NotFound("Student not found");

            return NoContent();
        }

        // =========================
        // Student Features
        // =========================

        // GET: api/students/courses
        [HttpGet("courses")]
        public async Task<IActionResult> GetAvailableCourses()
        {
            var courses = await studentService.GetAvailableCoursesAsync();
            return Ok(courses);
        }

        // GET: api/students/{studentId}/enrollments
        [HttpGet("{studentId:int}/enrollments")]
        public async Task<IActionResult> GetMyEnrollments(int studentId)
        {
            var enrollments = await studentService.GetMyEnrollmentsAsync(studentId);
            return Ok(enrollments);
        }

        // GET: api/students/{studentId}/attendance
        [HttpGet("{studentId:int}/attendance")]
        public async Task<IActionResult> GetMyAttendance(int studentId)
        {
            var attendance = await studentService.GetMyAttendanceAsync(studentId);
            return Ok(attendance);
        }
    }
}
