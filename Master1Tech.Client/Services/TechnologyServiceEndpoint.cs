using Master1Tech.Client.Shared;
using Master1Tech.Shared.DTOs.Technology;

namespace Master1Tech.Client.Services
{
    public class TechnologyServiceEndpoint : ITechnologyServiceEndpoint
    {
        private readonly IHttpService _httpService;
        public TechnologyServiceEndpoint(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<TechnologySummaryDto>> GetAllTechnologiesAsync()
        {
            var technologies = await _httpService.Get<List<TechnologySummaryDto>>("api/Technologies/all");
            return technologies ?? new List<TechnologySummaryDto>();
        }
    }
}
