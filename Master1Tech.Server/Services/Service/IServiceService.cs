using Master1Tech.Shared.DTOs.Service;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Service
{
    public interface IServiceService
    {
        PagedResultDto<ServiceDto> GetServices(string? name, int page);
        Task<ServiceDto?> GetServiceAsync(int serviceId);
        Task<ServiceDto?> GetServiceWithCompaniesAsync(int serviceId);
        Task<ServiceDto> AddServiceAsync(ServiceCreateDto serviceCreateDto);
        Task<ServiceDto?> UpdateServiceAsync(ServiceUpdateDto serviceUpdateDto);
        Task<bool> DeleteServiceAsync(int serviceId);
        Task<bool> ServiceExistsAsync(int serviceId);
        Task<bool> ServiceNameExistsAsync(string name, int? excludeId = null);
        Task<List<ServiceSummaryDto>> GetAllServicesAsync();
    }
}
