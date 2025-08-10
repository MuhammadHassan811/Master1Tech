using Master1Tech.Shared.DTOs.Technology;

namespace Master1Tech.Client.Services
{
    public interface ITechnologyServiceEndpoint
    {
        Task<List<TechnologySummaryDto>> GetAllTechnologiesAsync();
    }
}
