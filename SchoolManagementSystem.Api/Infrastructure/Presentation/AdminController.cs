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
		[HttpGet("parents")]
		public async Task<ActionResult<PaginatedResultDto<ParentDto>>> GetParents([FromQuery] ParentsParams _params)
			=> await serviceManager.AdminService.GetParentsAsync(_params);
		[HttpGet("parents/{id}")]
		public async Task<ActionResult<ParentDto>> GetParentById(int id)
			=> await serviceManager.AdminService.GetParentByIdAsync(id);
	}
}
