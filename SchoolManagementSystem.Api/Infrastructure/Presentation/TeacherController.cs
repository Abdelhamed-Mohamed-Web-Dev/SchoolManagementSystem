using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;

namespace Presentation.Controllers
{
    public class TeachersController(IServiceManager serviceManager) : ApiBaseController
    {
        // GET: api/teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAll()
        {
            var teachers = await serviceManager.TeacherService.GetTeachersAsync(new Shared.Params.TeachersParams());
            return Ok(teachers);
        }

        // GET: api/teachers/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await serviceManager.TeacherService.GetTeacherByIdAsync(id);
            return Ok(teacher);
        }

        // GET: api/teachers/{id}/subjects
        [HttpGet("{id:int}/subjects")]
        public async Task<IActionResult> GetSubjects(int id)
        {
            var subjects = await serviceManager.TeacherService.GetTeacherSubjectsAsync(id);
            return Ok(subjects);
        }

        // GET: api/teachers/{id}/classes
        [HttpGet("{id:int}/classes")]
        public async Task<IActionResult> GetClasses(int id)
        {
            var classes = await serviceManager.TeacherService.GetMyClassesAsync(id);
            return Ok(classes);
        }

        // GET: api/teachers/{id}/students
        [HttpGet("{id:int}/students")]
        public async Task<IActionResult> GetStudents(int id)
        {
            var students = await serviceManager.TeacherService.GetMyStudentsAsync(id);
            return Ok(students);
        }

        // GET: api/teachers/{id}/exams
        [HttpGet("{id:int}/exams")]
        public async Task<IActionResult> GetExams(int id)
        {
            var exams = await serviceManager.TeacherService.GetExamSchedulesAsync(id);
            return Ok(exams);
        }

        // GET: api/exams/{examId}/results
        [HttpGet("exams/{examId:int}/results")]
        public async Task<IActionResult> GetExamResults(int examId)
        {
            var results = await serviceManager.TeacherService.GetExamResultsAsync(examId);
            return Ok(results);
        }

        // POST: api/exams/{examId}/results
        [HttpPost("exams/{examId:int}/results")]
        public async Task<IActionResult> SetExamResult(int examId, [FromBody] GradeResultDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await serviceManager.TeacherService.SetStudentScoreAsync(examId, dto.StudentId, dto.Score);
            return NoContent();
        }
    }
}