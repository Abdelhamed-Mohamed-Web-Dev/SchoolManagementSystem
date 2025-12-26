using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
	public class AdminController(IServiceManager serviceManager) : ApiBaseController
	{
		// Admin-specific endpoints (students/teachers) should be implemented here.
	}
}
