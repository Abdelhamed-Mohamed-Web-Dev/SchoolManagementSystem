using ServiceAbstraction.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAbstraction
{
	public interface IServiceManager
	{
		public IAdminService AdminService { get; }
		public IAuthenticationService AuthenticationService { get; }
	}
}
