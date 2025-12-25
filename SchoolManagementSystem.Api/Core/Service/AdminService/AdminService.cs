using Domain.Exceptions.NotFoundExceptions;
using Service.ConcreteSpecifications;
using Shared.Params;

namespace Service.AdminService
{
	public class AdminService(IUnitOfWork unitOfWork, IMapper mapper) : IAdminService
	{
		public async Task<ParentDto> GetParentByIdAsync(int id)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(id);
			return parent is not null
				? mapper.Map<ParentDto>(parent)
				: throw new ParentNotFoundException(id);
		}

		public async Task<PaginatedResultDto<ParentDto>> GetParentsAsync(ParentsParams _params)
		{
			var parents = await unitOfWork.GetRepository<Parent, int>().GetAllAsync(new ParentSpecifications(_params));
			var dto = mapper.Map<IEnumerable<ParentDto>>(parents);
			var total = await unitOfWork.GetRepository<Parent, int>().CountAsync(new ParentSpecifications());
			return new PaginatedResultDto<ParentDto>(dto.Count(), _params.PageIndex, total, dto);
		}

		public async Task<ParentDto> CreateParentAsync(CreateParentDto dto)
		{
			var parent = mapper.Map<Parent>(dto);
			await unitOfWork.GetRepository<Parent, int>().AddAsync(parent);
			await unitOfWork.SaveChangesAsync();
			return mapper.Map<ParentDto>(parent);
		}

		public async Task UpdateParentAsync(int id, UpdateParentDto dto)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(id);
			if (parent is null) throw new ParentNotFoundException(id);
			mapper.Map(dto, parent);
			unitOfWork.GetRepository<Parent, int>().Update(parent);
			await unitOfWork.SaveChangesAsync();
		}

		public async Task DeleteParentAsync(int id)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(id);
			if (parent is null) throw new ParentNotFoundException(id);
			// ensure not linked to students
			var fullParent = await unitOfWork.GetRepository<Parent, int>().GetAsync(new ParentByIdSpecifications(id));
			if (fullParent is not null && fullParent.ParentStudents.Any())
				throw new ValidationException(new[] { "Cannot delete parent with linked students." });
			unitOfWork.GetRepository<Parent, int>().Delete(parent);
			await unitOfWork.SaveChangesAsync();
		}

		public async Task LinkParentToStudentAsync(int parentId, int studentId)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(new ParentByIdSpecifications(parentId));
			if (parent is null) throw new ParentNotFoundException(parentId);

			var student = await unitOfWork.GetRepository<Student, int>().GetAsync(studentId);
			if (student is null) throw new StudentNotFoundException(studentId);

			if (parent.ParentStudents.Any(ps => ps.StudentId == studentId))
				return; // already linked

			parent.ParentStudents.Add(new ParentStudent { ParentId = parentId, StudentId = studentId });
			unitOfWork.GetRepository<Parent, int>().Update(parent);
			await unitOfWork.SaveChangesAsync();
		}

		public async Task UnlinkParentFromStudentAsync(int parentId, int studentId)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(new ParentByIdSpecifications(parentId));
			if (parent is null) throw new ParentNotFoundException(parentId);

			var link = parent.ParentStudents.FirstOrDefault(ps => ps.StudentId == studentId);
			if (link is null) return; // no-op

			parent.ParentStudents.Remove(link);
			unitOfWork.GetRepository<Parent, int>().Update(parent);
			await unitOfWork.SaveChangesAsync();
		}

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
