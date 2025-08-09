using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Models
{
    public interface IServiceRepository
    {
        PagedResult<Service> GetServices(string? name, int page);
        Task<Service?> GetServiceAsync(int serviceId);
        Task<Service?> GetServiceWithCompaniesAsync(int serviceId);
        Task<Service> AddServiceAsync(Service service);
        Task<Service?> UpdateServiceAsync(Service service);
        Task<Service?> DeleteServiceAsync(int serviceId);
        Task<bool> ServiceExistsAsync(int serviceId);
        Task<bool> ServiceNameExistsAsync(string name, int? excludeId = null);
        Task<List<Service>> GetAllServicesAsync();
        Task<int> GetCompanyCountForServiceAsync(int serviceId);
    }
}
