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
		#region Teacher
		Task<PaginatedResultDto<TeacherDto>> GetTeachersAsync(TeachersParams _params);
		Task<TeacherDto> GetTeacherByIdAsync(int id);
		Task<TeacherDto> CreateTeacherAsync(CreateTeacherDto dto);
		Task<string> UpdateTeacherAsync(UpdateTeacherDto dto);
		#endregion

		#region Parent
		Task<PaginatedResultDto<ParentDto>> GetParentsAsync(ParentsParams _params);
		Task<ParentDto> GetParentByIdAsync(int id);
		Task<ParentDto> CreateParentAsync(CreateParentDto dto);
		Task<string> UpdateParentAsync(UpdateParentDto dto);
		Task<string> DeleteParentAsync(int id);
		#endregion

		#region Student
		Task<PaginatedResultDto<StudentDto>> GetStudentsAsync(StudentsParams _params);
		Task<StudentDto> GetStudentByIdAsync(int id);
		Task<StudentDto> CreateStudentAsync(CreateStudentDto dto);
		Task<string> UpdateStudentAsync(UpdateStudentDto dto);
		#endregion
	}
}
