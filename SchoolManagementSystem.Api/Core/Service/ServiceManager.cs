using Domain.Contracts;
using ServiceAbstraction;
using ServiceAbstraction.Admin;
using ServiceAbstraction.Teacher;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Service
{
	public class ServiceManger : IServiceManager
	{
		readonly Lazy<IAdminService> adminService;
		readonly Lazy<IStudentService> studentService;
		readonly Lazy<IAuthenticationService> authenticationService;
		readonly Lazy<IParentService> parentService;
		readonly Lazy<ITeacherService> teacherService;

		public ServiceManger(IUnitOfWork unitOfWork,IMapper mapper,UserManager<IdentityUser> userManager,IConfiguration configuration)
		{
			adminService = new Lazy<IAdminService>(() => new AdminService.AdminService(unitOfWork,mapper));
			studentService = new Lazy<IStudentService>(() => new StudentService.StudentService( unitOfWork, mapper));
			authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, unitOfWork, mapper, configuration));
			parentService = new Lazy<IParentService>(() => new ParentService.ParentService(unitOfWork, mapper));
			teacherService = new Lazy<ITeacherService>(() => new TeacherService.TeacherService(unitOfWork, mapper));
		}

		public IAdminService AdminService => adminService.Value;
		public IStudentService StudentService => studentService.Value;
		public IAuthenticationService AuthenticationService => authenticationService.Value;
		public IParentService ParentService => parentService.Value;
		public ITeacherService TeacherService => teacherService.Value;
	}
}
