using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using ServiceAbstraction.student;
using Shared;

namespace Presentation.Controllers
{
    public class StudentsController(IServiceManager serviceManager) :ApiBaseController
    {
        
        // =========================
        // CRUD
        // =========================

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var students = await serviceManager.StudentService.GetAllAsync();
            return students.ToList();
        }

        // GET: api/students/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await serviceManager.StudentService.GetByIdAsync(id);

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await serviceManager.StudentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // DELETE: api/students/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await serviceManager.StudentService.DeleteAsync(id);

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
            var courses = await serviceManager.StudentService.GetAvailableCoursesAsync();
            return Ok(courses);
        }

        // GET: api/students/{studentId}/enrollments
        [HttpGet("{studentId:int}/classes")]
        public async Task<IActionResult> GetClasses(int studentId)
        {
            var enrollments = await serviceManager.StudentService.GetClassesAsync(studentId);
            return Ok(enrollments);
        }

        // GET: api/students/{studentId}/attendance
        [HttpGet("{studentId:int}/attendance")]
        public async Task<IActionResult> GetMyAttendance(int studentId)
        {
            var attendance = await serviceManager.StudentService.GetMyAttendanceAsync(studentId);
            return Ok(attendance);
        }
    }
}
