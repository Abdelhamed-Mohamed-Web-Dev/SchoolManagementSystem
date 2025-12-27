using Domain.Contracts;
using ServiceAbstraction;
using ServiceAbstraction.Admin;
using ServiceAbstraction.Parent;
using ServiceAbstraction.student;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
	public class ServiceManger : IServiceManager
	{
		readonly Lazy<IAdminService> adminService;
		readonly Lazy<IStudentService> studentService;
		readonly Lazy<IAuthenticationService> authenticationService;
		readonly Lazy<IParentService> parentService;

		public ServiceManger(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager, IConfiguration configuration)
		{
			adminService = new Lazy<IAdminService>(() => new AdminService.AdminService(unitOfWork, mapper, userManager));
			studentService = new Lazy<IStudentService>(() => new StudentService.StudentService(unitOfWork, mapper));
			authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, unitOfWork, mapper, configuration));
			parentService = new Lazy<IParentService>(() => new ParentService.ParentService(unitOfWork, mapper,userManager));
		}

		public IAdminService AdminService => adminService.Value;
		public IAuthenticationService AuthenticationService => authenticationService.Value;
		public IStudentService StudentService => studentService.Value;
		public IParentService ParentService => parentService.Value;
	}
}
