using Domain.Exceptions;
using Domain.Exceptions.NotFoundExceptions;
using Microsoft.AspNetCore.Identity;
using Service.ConcreteSpecifications;
using ServiceAbstraction.Parent;
using Shared.Params;
using System.Linq;

namespace Service.ParentService
{
	public class ParentService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager ) : IParentService
	{
		public async Task<PaginatedResultDto<ParentDto>> GetParentsAsync(ParentsParams _params)
		{
			var parents = await unitOfWork.GetRepository<Parent, int>().GetAllAsync(new ParentSpecifications(_params));
			var dto = mapper.Map<IEnumerable<ParentDto>>(parents);
			var total = await unitOfWork.GetRepository<Parent, int>().CountAsync();
			return new PaginatedResultDto<ParentDto>(dto.Count(), _params.PageIndex, total, dto);
		}

		public async Task<ParentDto> GetParentByIdAsync(int id)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(id);
			return parent is not null
				? mapper.Map<ParentDto>(parent)
				: throw new ParentNotFoundException(id);
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

		public async Task UpdateParentAsync(UpdateParentDto dto)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(dto.Id);
			if (parent is null) throw new ParentNotFoundException(dto.Id);
			parent.FullName = dto.FullName;
			unitOfWork.GetRepository<Parent, int>().Update(parent);
			await unitOfWork.SaveChangesAsync();
		}

		public async Task DeleteParentAsync(int id)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(new ParentSpecifications(id));
			if (parent is null) throw new ParentNotFoundException(id);

			//// ensure not linked to students
			if (parent.Students.Any())
				throw new ValidationException(new[] { "Cannot delete parent with linked students." });

			unitOfWork.GetRepository<Parent, int>().Delete(parent);
			await unitOfWork.SaveChangesAsync();
		}

		public async Task LinkParentToStudentAsync(int parentId, int studentId)
		{
			var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(new ParentSpecifications(parentId));
			if (parent is null) throw new ParentNotFoundException(parentId);

			var student = await unitOfWork.GetRepository<Student, int>().GetAsync(studentId);
			if (student is null) throw new StudentNotFoundException(studentId);

			if (student.ParentId == parentId)
				return; // already linked

			student.ParentId = parentId;

			unitOfWork.GetRepository<Student, int>().Update(student);
			await unitOfWork.SaveChangesAsync();
		}

		//public async Task UnlinkParentFromStudentAsync(int parentId, int studentId)
		//{
		//	var parent = await unitOfWork.GetRepository<Parent, int>().GetAsync(parentId);
		//	if (parent is null) throw new ParentNotFoundException(parentId);

		//	var student = await unitOfWork.GetRepository<Student, int>().GetAsync(studentId);
		//	if (student is null) throw new StudentNotFoundException(studentId);

		//	var link = parent.ParentStudents.FirstOrDefault(ps => ps.StudentId == studentId);
		//	if (student.ParentId != parentId) return; // no-op

		//	parent.ParentStudents.Remove(link);
		//	unitOfWork.GetRepository<Parent, int>().Update(parent);
		//	await unitOfWork.SaveChangesAsync();
		//}
	}
}
