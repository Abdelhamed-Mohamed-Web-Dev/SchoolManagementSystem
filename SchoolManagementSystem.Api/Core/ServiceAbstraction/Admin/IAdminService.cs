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
		Task<PaginatedResultDto<ParentDto>> GetParentsAsync(ParentsParams _params);
		Task<ParentDto> GetParentByIdAsync(int id);
		Task<ParentDto> CreateParentAsync(CreateParentDto dto);
		Task UpdateParentAsync(int id, UpdateParentDto dto);
		Task DeleteParentAsync(int id);
		Task LinkParentToStudentAsync(int parentId, int studentId);
		Task UnlinkParentFromStudentAsync(int parentId, int studentId);
	}
}
