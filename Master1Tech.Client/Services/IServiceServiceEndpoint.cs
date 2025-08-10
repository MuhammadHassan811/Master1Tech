using Master1Tech.Shared.DTOs.Service;

namespace Master1Tech.Client.Services
{
    public interface IServiceServiceEndpoint
    {
        Task<List<ServiceSummaryDto>> GetAllServicesAsync();
    }
}
