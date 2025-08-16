using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.GetInTouch;
using Master1Tech.Shared.DTOs;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Models
{
    public interface IGetInTouchRepository
    {
        PagedResult<GetInTouch> GetGetInTouchRequests(string? email, bool? status, bool? isCompleted, int? service, int page);
        Task<GetInTouch?> GetGetInTouchAsync(int id);
        Task<GetInTouch?> GetGetInTouchWithCompanyAsync(int id);
        Task<GetInTouch> AddGetInTouchAsync(GetInTouch getInTouch);
        Task<GetInTouch?> UpdateGetInTouchAsync(GetInTouch getInTouch);
        Task<GetInTouch?> UpdateStatusAsync(int id, bool status, bool isCompleted);
        Task<GetInTouch?> DeleteGetInTouchAsync(int id);
        Task<bool> GetInTouchExistsAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);
        Task<List<GetInTouch>> GetPendingRequestsAsync();
        PagedResult<GetInTouch> GetInTouchQuery(string? name, int page);
        Task<List<GetInTouch>> GetAllRequestsAsync();
        Task<List<GetInTouch>> GetCompletedRequestsAsync();
        Task<List<GetInTouch>> GetRequestsByServiceAsync(int serviceId);
        Task<int> GetRequestCountByStatusAsync(bool status);
    }
}
