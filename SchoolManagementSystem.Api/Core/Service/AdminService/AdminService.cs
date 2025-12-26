using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.NotFoundExceptions;
using Service.ConcreteSpecifications;
using Shared.Params;

namespace Service.AdminService
{
	public class AdminService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager) : IAdminService
	{
		#region Parent
		public async Task<ParentDto> GetParentByIdAsync(int id)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(new ParentSpecifications(id));

			return parent is not null
				? mapper.Map<ParentDto>(parent)
				: throw new ParentNotFoundException(id);
		}

		public async Task<PaginatedResultDto<ParentDto>> GetParentsAsync(ParentsParams _params)
		{
			var parents = await unitOfWork.GetRepository<Parent, int>().GetAllAsync(new ParentSpecifications(_params));
			var dto = mapper.Map<IEnumerable<ParentDto>>(parents);
			var total = await unitOfWork.GetRepository<Parent, int>().CountAsync();
			return new PaginatedResultDto<ParentDto>(dto.Count(), _params.PageIndex, total, dto);
		}

		public async Task<ParentDto> CreateParentAsync(CreateParentDto dto)
		{
			var user = await userManager.FindByEmailAsync(dto.Email);

			if (user is null)
			{
				user = new();
				user.Email = dto.Email;
				user.Id = Guid.NewGuid().ToString();
				user.UserName = dto.UserName;
				user.PhoneNumber = dto.PhoneNumber;
				await userManager.CreateAsync(user, "Pa$5word");
				await userManager.AddToRoleAsync(user, "Parent");
			}

			var parent = new Parent() { FullName = dto.FullName, UserId = user.Id };
			await unitOfWork.GetRepository<Parent, int>().AddAsync(parent);
			await unitOfWork.SaveChangesAsync();
			return mapper.Map<ParentDto>(parent);
		}

		public async Task<string> UpdateParentAsync(UpdateParentDto dto)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(dto.Id);
			if (parent is null) throw new ParentNotFoundException(dto.Id);
			parent.FullName = dto.FullName;
			unitOfWork.GetRepository<Parent, int>().Update(parent);
			await unitOfWork.SaveChangesAsync();
			return $"{parent.FullName} Updated Successfully";
		}

		public async Task<string> DeleteParentAsync(int id)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(new ParentSpecifications(id));
			if (parent is null) throw new ParentNotFoundException(id);

			//// ensure not linked to students
			if (parent.Students.Any())
				throw new ValidationException(new[] { "Cannot delete parent with linked students." });

			unitOfWork.GetRepository<Parent, int>().Delete(parent);
			await unitOfWork.SaveChangesAsync();
			return $"{parent.FullName} Deleted Successfully";
		}
		#endregion

		#region Student

		public async Task<StudentDto> GetStudentByIdAsync(int id)
		{
			var student = await unitOfWork.GetRepository<Student, int>().GetAsync(new StudentSpecifications(id));
			return student is not null
				? mapper.Map<StudentDto>(student)
				: throw new StudentNotFoundException(id);
		}

		public async Task<PaginatedResultDto<StudentDto>> GetStudentsAsync(StudentsParams _params)
		{
			var students = await unitOfWork.GetRepository<Student, int>().GetAllAsync(new StudentSpecifications(_params));
			var dto = mapper.Map<IEnumerable<StudentDto>>(students);
			var total = await unitOfWork.GetRepository<Student, int>().CountAsync();
			return new PaginatedResultDto<StudentDto>(dto.Count(), _params.PageIndex, total, dto);
		}
		public async Task<StudentDto> CreateStudentAsync(CreateStudentDto dto)
		{
			var _user = new IdentityUser()
			{
				Id = Guid.NewGuid().ToString(),
				Email = dto.Email,
				UserName = dto.UserName
			};
			await userManager.CreateAsync(_user, "Pa$5word");
			await userManager.AddToRoleAsync(_user, "Student");

			var _class = await unitOfWork.GetRepository<Class, int>().GetAsync(dto.ClassId);
			var _grade = await unitOfWork.GetRepository<Grade, int>().GetAsync(dto.GradeId);
			var _parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(dto.ParentId);

			if (_class is null) throw new ClassNotFoundException(dto.ClassId);
			if (_grade is null) throw new GradeNotFoundException(dto.GradeId);
			if (_parent is null) throw new ParentNotFoundException(dto.ParentId);

			var student = new Student()
			{
				FullName = dto.FullName,
				DateOfBirth = dto.DateOfBirth,
				Gender = dto.Gender,
				EnrollmentDate = DateTime.UtcNow,

				UserId = _user.Id,
				ClassId = _class.Id,
				GradeId = _grade.Id,
				ParentId = _parent.Id,
			};

			await unitOfWork.GetRepository<Student, int>().AddAsync(student);
			await unitOfWork.SaveChangesAsync();
			return mapper.Map<StudentDto>(student);
		}

		public async Task<string> UpdateStudentAsync(UpdateStudentDto dto)
		{
			var student = await unitOfWork.GetRepository<Student, int>().GetAsync(dto.Id);
			if (student is null) throw new StudentNotFoundException(dto.Id);

			if (dto.ParentId is not null)
			{
				var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(dto?.ParentId ?? 0);
				if (parent is null) throw new ParentNotFoundException(dto?.ParentId ?? 0);
			}
			if (dto.GradeId is not null)
			{
				var grade = await unitOfWork.GetRepository<Grade, int>().GetAsync(dto?.GradeId ?? 0);
				if (grade is null) throw new GradeNotFoundException(dto?.GradeId ?? 0);
			}
			if (dto.ClassId is not null)
			{
				var _class = await unitOfWork.GetRepository<Class, int>().GetAsync(dto?.ClassId ?? 0);
				if (_class is null) throw new ClassNotFoundException(dto?.ClassId ?? 0);
			}

			student.ParentId = dto?.ParentId ?? 0;
			student.ClassId = dto?.ClassId ?? 0;
			student.GradeId = dto?.GradeId ?? 0;

			unitOfWork.GetRepository<Student, int>().Update(student);
			await unitOfWork.SaveChangesAsync();
			return $"Student [[{student.FullName}]] Updated Successfully";
		}

		#endregion

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
