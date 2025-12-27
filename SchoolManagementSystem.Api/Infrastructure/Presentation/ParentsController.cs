using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.Params;
using Microsoft.AspNetCore.Authorization;

namespace Presentation
{
    [Authorize]
    [Route("api/[controller]")]
    public class ParentsController : ApiBaseController
    {
        readonly IServiceManager serviceManager;
        public ParentsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResultDto<ParentDto>>> Get([FromQuery] ParentsParams _params)
            => await serviceManager.ParentService.GetParentsAsync(_params);

        [HttpGet("{id}")]
        public async Task<ActionResult<ParentDto>> GetById(int id)
            => await serviceManager.ParentService.GetParentByIdAsync(id);

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ParentDto>> Create([FromBody] CreateParentDto dto)
        {
            var created = await serviceManager.ParentService.CreateParentAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateParentDto dto)
        {
            await serviceManager.ParentService.UpdateParentAsync( dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await serviceManager.ParentService.DeleteParentAsync(id);
            return NoContent();
        }

        [HttpPost("{parentId}/students/{studentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> LinkStudent(int parentId, int studentId)
        {
            await serviceManager.ParentService.LinkParentToStudentAsync(parentId, studentId);
            return NoContent();
        }

        //[HttpDelete("{parentId}/students/{studentId}")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UnlinkStudent(int parentId, int studentId)
        //{
        //    await serviceManager.ParentService.UnlinkParentFromStudentAsync(parentId, studentId);
        //    return NoContent();
        //}
    }
}
