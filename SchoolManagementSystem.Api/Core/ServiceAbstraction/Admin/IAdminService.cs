using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAbstraction.Admin
{
	public interface IAdminService
	{
		Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
		Task<Student> GetAllStudentByIdAsync(int id);
		Task<IEnumerable<Student>> GetTop10StudentsAsync();
		// methods
		// new
		Task<Teacher> GetTeacherByIdAsync(int id);
	}
}
