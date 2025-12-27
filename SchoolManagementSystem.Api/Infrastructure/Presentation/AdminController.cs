using Domain.Entities;
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
		[HttpPost("parents")]
		public async Task<ActionResult<ParentDto>> CreateParent([FromBody] CreateParentDto dto)
			=> await serviceManager.AdminService.CreateParentAsync(dto);
		[HttpPut("parents")]
		public async Task<ActionResult<string>> UpdateParent([FromBody] UpdateParentDto dto)
			=> await serviceManager.AdminService.UpdateParentAsync(dto);
		[HttpDelete("parents/{id}")]
		public async Task<ActionResult<string>> DeleteParent(int id)
			=> await serviceManager.AdminService.DeleteParentAsync(id);
		[HttpGet("students")]
		public async Task<ActionResult<PaginatedResultDto<StudentDto>>> GetParents([FromQuery] StudentsParams _params)
			=> await serviceManager.AdminService.GetStudentsAsync(_params);
		[HttpGet("students/{id}")]
		public async Task<ActionResult<StudentDto>> GetStudentById(int id)
			=> await serviceManager.AdminService.GetStudentByIdAsync(id);
		[HttpPost("students")]
		public async Task<ActionResult<StudentDto>> CreateStudent([FromBody] CreateStudentDto dto)
			=> await serviceManager.AdminService.CreateStudentAsync(dto);
		[HttpPut("students")]
		public async Task<ActionResult<string>> UpdateStudent([FromBody] UpdateStudentDto dto)
			=> await serviceManager.AdminService.UpdateStudentAsync(dto);

	}
}
