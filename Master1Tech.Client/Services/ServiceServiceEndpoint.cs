using Master1Tech.Client.Shared;
using Master1Tech.Shared.DTOs.Service;

namespace Master1Tech.Client.Services
{
    public class ServiceServiceEndpoint : IServiceServiceEndpoint
    {
        private readonly IHttpService _httpService;

        public ServiceServiceEndpoint(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<ServiceSummaryDto>> GetAllServicesAsync()
        {
            var companies = await _httpService.Get<List<ServiceSummaryDto>>($"api/Services/all");
            return companies ?? new List<ServiceSummaryDto>();
        }
    }
}
