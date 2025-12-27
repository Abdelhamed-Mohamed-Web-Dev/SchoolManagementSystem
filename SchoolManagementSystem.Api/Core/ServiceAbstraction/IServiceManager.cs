using ServiceAbstraction.Admin;
using ServiceAbstraction.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAbstraction
{
	public interface IServiceManager
	{
		public IAdminService AdminService { get; }
		public IStudentService StudentService { get; }
		public IAuthenticationService AuthenticationService { get; }
		public IParentService ParentService { get; }
		public ITeacherService TeacherService { get; }
	}
}
