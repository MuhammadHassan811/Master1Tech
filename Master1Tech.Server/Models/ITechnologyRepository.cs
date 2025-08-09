using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Models
{
    public interface ITechnologyRepository
    {
        PagedResult<Technology> GetTechnologies(string? name, string? category, int page);
        Task<Technology?> GetTechnologyAsync(int technologyId);
        Task<Technology?> GetTechnologyWithCompaniesAsync(int technologyId);
        Task<Technology> AddTechnologyAsync(Technology technology);
        Task<Technology?> UpdateTechnologyAsync(Technology technology);
        Task<Technology?> DeleteTechnologyAsync(int technologyId);
        Task<bool> TechnologyExistsAsync(int technologyId);
        Task<bool> TechnologyNameExistsAsync(string name, int? excludeId = null);
        Task<List<Technology>> GetAllTechnologiesAsync();
        Task<List<Technology>> GetTechnologiesByCategoryAsync(string category);
        Task<List<string>> GetAllCategoriesAsync();
        Task<int> GetCompanyCountForTechnologyAsync(int technologyId);
    }
}
