using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.Params;

namespace Presentation
{
    public class ParentsController : ApiBaseController
    {
        readonly IServiceManager serviceManager;
        public ParentsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResultDto<ParentDto>>> Get([FromQuery] ParentsParams _params)
            => await serviceManager.AdminService.GetParentsAsync(_params);

        [HttpGet("{id}")]
        public async Task<ActionResult<ParentDto>> GetById(int id)
            => await serviceManager.AdminService.GetParentByIdAsync(id);

        [HttpPost]
        public async Task<ActionResult<ParentDto>> Create([FromBody] CreateParentDto dto)
        {
            var created = await serviceManager.AdminService.CreateParentAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateParentDto dto)
        {
            await serviceManager.AdminService.UpdateParentAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await serviceManager.AdminService.DeleteParentAsync(id);
            return NoContent();
        }

    }
}
