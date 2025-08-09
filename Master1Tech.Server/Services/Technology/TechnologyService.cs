using Master1Tech.Server.Models;
using Master1Tech.Shared.DTOs.Technology;
using Master1Tech.Shared.DTOs;
using Master1Tech.Server.Services.Mapping.TechnologyMapping;

namespace Master1Tech.Server.Services.Technology
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly ITechnologyMappingService _mappingService;

        public TechnologyService(ITechnologyRepository technologyRepository, ITechnologyMappingService mappingService)
        {
            _technologyRepository = technologyRepository;
            _mappingService = mappingService;
        }

        public PagedResultDto<TechnologyDto> GetTechnologies(string? name, string? category, int page)
        {
            var result = _technologyRepository.GetTechnologies(name, category, page);
            return _mappingService.MapToPagedResultDto(result);
        }

        public async Task<TechnologyDto?> GetTechnologyAsync(int technologyId)
        {
            var technology = await _technologyRepository.GetTechnologyAsync(technologyId);
            if (technology == null) return null;

            var companyCount = await _technologyRepository.GetCompanyCountForTechnologyAsync(technologyId);
            return _mappingService.MapToTechnologyDto(technology, companyCount);
        }

        public async Task<TechnologyDto?> GetTechnologyWithCompaniesAsync(int technologyId)
        {
            var technology = await _technologyRepository.GetTechnologyWithCompaniesAsync(technologyId);
            if (technology == null) return null;

            var companyCount = technology.CompanyTechnologies?.Count ?? 0;
            return _mappingService.MapToTechnologyDto(technology, companyCount);
        }

        public async Task<TechnologyDto> AddTechnologyAsync(TechnologyCreateDto technologyCreateDto)
        {
            // Check if technology name already exists
            if (await _technologyRepository.TechnologyNameExistsAsync(technologyCreateDto.Name))
            {
                throw new InvalidOperationException($"Technology with name '{technologyCreateDto.Name}' already exists.");
            }

            var technology = _mappingService.MapToTechnologyEntity(technologyCreateDto);
            var addedTechnology = await _technologyRepository.AddTechnologyAsync(technology);
            return _mappingService.MapToTechnologyDto(addedTechnology);
        }

        public async Task<TechnologyDto?> UpdateTechnologyAsync(TechnologyUpdateDto technologyUpdateDto)
        {
            // Check if technology exists
            if (!await _technologyRepository.TechnologyExistsAsync(technologyUpdateDto.TechnologyID))
            {
                return null;
            }

            // Check if technology name already exists for another technology
            if (await _technologyRepository.TechnologyNameExistsAsync(technologyUpdateDto.Name, technologyUpdateDto.TechnologyID))
            {
                throw new InvalidOperationException($"Technology with name '{technologyUpdateDto.Name}' already exists.");
            }

            var technology = _mappingService.MapToTechnologyEntity(technologyUpdateDto);
            var updatedTechnology = await _technologyRepository.UpdateTechnologyAsync(technology);

            if (updatedTechnology != null)
            {
                var companyCount = await _technologyRepository.GetCompanyCountForTechnologyAsync(updatedTechnology.TechnologyID);
                return _mappingService.MapToTechnologyDto(updatedTechnology, companyCount);
            }

            return null;
        }

        public async Task<bool> DeleteTechnologyAsync(int technologyId)
        {
            try
            {
                var result = await _technologyRepository.DeleteTechnologyAsync(technologyId);
                return result != null;
            }
            catch (InvalidOperationException)
            {
                // Re-throw the exception so the controller can handle it
                throw;
            }
        }

        public async Task<bool> TechnologyExistsAsync(int technologyId)
        {
            return await _technologyRepository.TechnologyExistsAsync(technologyId);
        }

        public async Task<bool> TechnologyNameExistsAsync(string name, int? excludeId = null)
        {
            return await _technologyRepository.TechnologyNameExistsAsync(name, excludeId);
        }

        public async Task<List<TechnologySummaryDto>> GetAllTechnologiesAsync()
        {
            var technologies = await _technologyRepository.GetAllTechnologiesAsync();
            return technologies.Select(_mappingService.MapToTechnologySummaryDto).ToList();
        }

        public async Task<List<TechnologySummaryDto>> GetTechnologiesByCategoryAsync(string category)
        {
            var technologies = await _technologyRepository.GetTechnologiesByCategoryAsync(category);
            return technologies.Select(_mappingService.MapToTechnologySummaryDto).ToList();
        }

        public async Task<List<TechnologyCategoryDto>> GetTechnologiesGroupedByCategoryAsync()
        {
            var technologies = await _technologyRepository.GetAllTechnologiesAsync();
            var grouped = technologies
                .GroupBy(t => t.Category)
                .Select(g => new TechnologyCategoryDto
                {
                    Category = g.Key,
                    Technologies = g.Select(_mappingService.MapToTechnologySummaryDto).ToList(),
                    Count = g.Count()
                })
                .OrderBy(g => g.Category)
                .ToList();

            return grouped;
        }

        public async Task<List<string>> GetAllCategoriesAsync()
        {
            return await _technologyRepository.GetAllCategoriesAsync();
        }
    }
}
