using Domain.Contracts;
using ServiceAbstraction;
using ServiceAbstraction.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
	public class ServiceManger : IServiceManager
	{
		readonly Lazy<IAdminService> adminService;
		readonly Lazy<IAuthenticationService> authenticationService;

		public ServiceManger(IUnitOfWork unitOfWork,IMapper mapper,UserManager<IdentityUser> userManager,IConfiguration configuration)
		{
			adminService = new Lazy<IAdminService>(() => new AdminService.AdminService(unitOfWork,mapper));
			authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, unitOfWork, mapper, configuration));
		}

		public IAdminService AdminService => adminService.Value;
		public IAuthenticationService AuthenticationService => authenticationService.Value;
	}
}
