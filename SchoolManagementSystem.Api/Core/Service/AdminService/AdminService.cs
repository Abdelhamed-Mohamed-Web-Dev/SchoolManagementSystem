using Domain.Exceptions.NotFoundExceptions;
using Shared.Params;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System;

namespace Service.AdminService
{
	public class AdminService(IUnitOfWork unitOfWork, IMapper mapper) : IAdminService
	{
		public async Task<StudentDto> GetStudentByIdAsync(int id)
		{
			var student = await unitOfWork.GetRepository<Student, int>().GetAsync(id);
			return student is not null
				? mapper.Map<StudentDto>(student)
				: throw new StudentNotFoundException(id);
		}

		public Task<IEnumerable<StudentDto>> GetStudentsAsync(StudentsParams _params)
		{
			throw new NotImplementedException();
		}

		public async Task<TeacherDto> GetTeacherByIdAsync(int id)
		{
			var teacher = await unitOfWork.GetRepository<Teacher, int>().GetAsync(id);
			return teacher is not null
				? mapper.Map<TeacherDto>(teacher)
				: throw new TeacherNotFoundException(id);
		}

		public Task<IEnumerable<TeacherDto>> GetTeachersAsync(TeachersParams _params)
		{
			throw new NotImplementedException();
		}
	}
}
