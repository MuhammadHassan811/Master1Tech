using Master1Tech.Shared.DTOs.Technology;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Technology
{
    public interface ITechnologyService
    {
        PagedResultDto<TechnologyDto> GetTechnologies(string? name, string? category, int page);
        Task<TechnologyDto?> GetTechnologyAsync(int technologyId);
        Task<TechnologyDto?> GetTechnologyWithCompaniesAsync(int technologyId);
        Task<TechnologyDto> AddTechnologyAsync(TechnologyCreateDto technologyCreateDto);
        Task<TechnologyDto?> UpdateTechnologyAsync(TechnologyUpdateDto technologyUpdateDto);
        Task<bool> DeleteTechnologyAsync(int technologyId);
        Task<bool> TechnologyExistsAsync(int technologyId);
        Task<bool> TechnologyNameExistsAsync(string name, int? excludeId = null);
        Task<List<TechnologySummaryDto>> GetAllTechnologiesAsync();
        Task<List<TechnologySummaryDto>> GetTechnologiesByCategoryAsync(string category);
        Task<List<TechnologyCategoryDto>> GetTechnologiesGroupedByCategoryAsync();
        Task<List<string>> GetAllCategoriesAsync();
    }
}
