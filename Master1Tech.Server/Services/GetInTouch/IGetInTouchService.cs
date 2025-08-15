using Master1Tech.Shared.DTOs.GetInTouch;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.GetInTouch
{
    public interface IGetInTouchService
    {
        PagedResultDto<GetInTouchDto> GetGetInTouchRequests(string? email, bool? status, bool? isCompleted, int? service, int page);
        Task<GetInTouchDto?> GetGetInTouchAsync(int id);
        Task<GetInTouchDto?> GetGetInTouchWithCompanyAsync(int id);
        Task<GetInTouchDto> AddGetInTouchAsync(GetInTouchCreateDto getInTouchCreateDto);
        Task<GetInTouchDto?> UpdateGetInTouchAsync(GetInTouchUpdateDto getInTouchUpdateDto);
        Task<GetInTouchDto?> UpdateStatusAsync(GetInTouchStatusUpdateDto statusUpdateDto);
        Task<bool> DeleteGetInTouchAsync(int id);
        Task<bool> GetInTouchExistsAsync(int id);
        Task<List<GetInTouchSummaryDto>> GetPendingRequestsAsync();
        Task<List<GetInTouchSummaryDto>> GetCompletedRequestsAsync();
        Task<List<GetInTouchSummaryDto>> GetRequestsByServiceAsync(int serviceId);
        Task<Dictionary<string, int>> GetRequestStatisticsAsync();
    }
}
