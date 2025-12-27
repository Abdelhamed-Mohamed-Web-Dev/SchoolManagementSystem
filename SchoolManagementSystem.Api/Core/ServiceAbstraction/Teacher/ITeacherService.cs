using Shared;
using Shared.Params;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAbstraction.Teacher
{
	public interface ITeacherService
	{
		Task<IEnumerable<TeacherDto>> GetTeachersAsync(TeachersParams _params);
		Task<TeacherDto> GetTeacherByIdAsync(int id);

n		Task<IEnumerable<TeacherSubjectDto>> GetTeacherSubjectsAsync(int teacherId);
		Task<IEnumerable<ClassDto>> GetMyClassesAsync(int teacherId);
		Task<IEnumerable<StudentWithParentsDto>> GetMyStudentsAsync(int teacherId);
		Task<IEnumerable<ExamDto>> GetExamSchedulesAsync(int teacherId);
		Task<IEnumerable<GradeResultDto>> GetExamResultsAsync(int examId);
		Task SetStudentScoreAsync(int examId, int studentId, int score);
	}
}