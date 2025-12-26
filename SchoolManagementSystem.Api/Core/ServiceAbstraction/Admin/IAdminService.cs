using Domain.Entities;
using Shared;
using Shared.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAbstraction.Admin
{
	public interface IAdminService
	{
		Task<IEnumerable<StudentDto>> GetStudentsAsync(StudentsParams _params);
		Task<StudentDto> GetStudentByIdAsync(int id);
		Task<IEnumerable<TeacherDto>> GetTeachersAsync(TeachersParams _params);
		Task<TeacherDto> GetTeacherByIdAsync(int id);
	}
}
