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
