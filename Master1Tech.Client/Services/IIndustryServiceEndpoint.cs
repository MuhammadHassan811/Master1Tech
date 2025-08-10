using Master1Tech.Shared.DTOs.Industry;

namespace Master1Tech.Client.Services
{
    public interface IIndustryServiceEndpoint
    {
        Task<List<IndustryDto>> GetAllIndustryAsync();
    }
}
