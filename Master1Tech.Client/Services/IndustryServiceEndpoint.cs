using Master1Tech.Client.Shared;
using Master1Tech.Shared.DTOs.Industry;

namespace Master1Tech.Client.Services
{
    public class IndustryServiceEndpoint : IIndustryServiceEndpoint
    {
        private readonly IHttpService _httpService;
        public IndustryServiceEndpoint(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<List<IndustryDto>> GetAllIndustryAsync()
        {
            var industries = await _httpService.Get<List<IndustryDto>>("api/Industry/all");
            return industries ?? new List<IndustryDto>();
        }
    }
}
