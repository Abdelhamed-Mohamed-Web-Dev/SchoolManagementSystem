using Shared;
using Shared.Params;
using System.Collections.Generic;

namespace ServiceAbstraction.Parent
{
    public interface IParentService
    {
        Task<PaginatedResultDto<ParentDto>> GetParentsAsync(ParentsParams _params);
        Task<ParentDto> GetParentByIdAsync(int id);
        Task<ParentDto> CreateParentAsync(CreateParentDto dto);
        Task UpdateParentAsync(int id, UpdateParentDto dto);
        Task DeleteParentAsync(int id);
        Task LinkParentToStudentAsync(int parentId, int studentId);
        Task UnlinkParentFromStudentAsync(int parentId, int studentId);
    }
}
