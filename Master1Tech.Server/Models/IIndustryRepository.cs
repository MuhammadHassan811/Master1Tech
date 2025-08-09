using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Models
{
    public interface IIndustryRepository
    {
        PagedResult<Industry> GetIndustries(string? name, int page);
        Task<Industry?> GetIndustryAsync(int industryId);
        Task<Industry> AddIndustryAsync(Industry industry);
        Task<Industry?> UpdateIndustryAsync(Industry industry);
        Task<Industry?> DeleteIndustryAsync(int industryId);
        Task<bool> IndustryExistsAsync(int industryId);
        Task<bool> IndustryNameExistsAsync(string name, int? excludeId = null);
    }
}