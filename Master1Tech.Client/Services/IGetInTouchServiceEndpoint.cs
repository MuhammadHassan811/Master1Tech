using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.GetInTouch;
using Master1Tech.Shared.DTOs.Technology;
using Master1Tech.Shared.Models;

namespace Master1Tech.Client.Services
{
    public interface IGetInTouchServiceEndpoint
    {
        Task<List<GetInTouchSummaryDto>> GetAllGetInTouchAsync();
        Task<PagedResult<GetInTouch>> GetInTouchAsync(string? name, int page);
        Task<GetInTouchDto> GetGetInTouch(int id);

        Task DeleteGetInTouch(int id);

        Task AddGetInTouch(GetInTouch getInTouch);

        Task UpdateGetInTouch(GetInTouch getInTouch);
    }
}