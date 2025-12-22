namespace Service.AdminService
{
	public class AdminService(IUnitOfWork unitOfWork, IMapper mapper) : IAdminService
	{
		public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
		{
			// get data from DB
			var students = await unitOfWork.GetRepository<Student, int>().GetAllAsync();

			if (students != null)
			{
				// Map to Dto
				var ListDto = mapper.Map<IEnumerable<StudentDto>>(students);
				// return Dto
				// return ListDto;
				return ListDto;
			}
			return new List<StudentDto>();
		}

		public Task<Student> GetAllStudentByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Student>> GetTop10StudentsAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Teacher> GetTeacherByIdAsync(int id)
		{
			throw new NotImplementedException();

		}
	}
}
