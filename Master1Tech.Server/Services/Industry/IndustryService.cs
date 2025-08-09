using Master1Tech.Server.Models;
using Master1Tech.Shared.DTOs.Industry;
using Master1Tech.Shared.DTOs;
using Master1Tech.Server.Services.Mapping.IndustryMapping;

namespace Master1Tech.Server.Services.Industry
{
    public class IndustryService : IIndustryService
    {
        private readonly IIndustryRepository _industryRepository;
        private readonly IIndustryMappingService _mappingService;

        public IndustryService(IIndustryRepository industryRepository, IIndustryMappingService mappingService)
        {
            _industryRepository = industryRepository;
            _mappingService = mappingService;
        }

        public PagedResultDto<IndustryDto> GetIndustries(string? name, int page)
        {
            var result = _industryRepository.GetIndustries(name, page);
            return _mappingService.MapToPagedResultDto(result);
        }

        public async Task<IndustryDto?> GetIndustryAsync(int industryId)
        {
            var industry = await _industryRepository.GetIndustryAsync(industryId);
            return industry != null ? _mappingService.MapToIndustryDto(industry) : null;
        }

        public async Task<IndustryDto> AddIndustryAsync(IndustryCreateDto industryCreateDto)
        {
            // Check if industry name already exists
            if (await _industryRepository.IndustryNameExistsAsync(industryCreateDto.Name))
            {
                throw new InvalidOperationException($"Industry with name '{industryCreateDto.Name}' already exists.");
            }

            var industry = _mappingService.MapToIndustryEntity(industryCreateDto);
            var addedIndustry = await _industryRepository.AddIndustryAsync(industry);
            return _mappingService.MapToIndustryDto(addedIndustry);
        }

        public async Task<IndustryDto?> UpdateIndustryAsync(IndustryUpdateDto industryUpdateDto)
        {
            // Check if industry exists
            if (!await _industryRepository.IndustryExistsAsync(industryUpdateDto.Id))
            {
                return null;
            }

            // Check if industry name already exists for another industry
            if (await _industryRepository.IndustryNameExistsAsync(industryUpdateDto.Name, industryUpdateDto.Id))
            {
                throw new InvalidOperationException($"Industry with name '{industryUpdateDto.Name}' already exists.");
            }

            var industry = _mappingService.MapToIndustryEntity(industryUpdateDto);
            var updatedIndustry = await _industryRepository.UpdateIndustryAsync(industry);
            return updatedIndustry != null ? _mappingService.MapToIndustryDto(updatedIndustry) : null;
        }

        public async Task<bool> DeleteIndustryAsync(int industryId)
        {
            var result = await _industryRepository.DeleteIndustryAsync(industryId);
            return result != null;
        }

        public async Task<bool> IndustryExistsAsync(int industryId)
        {
            return await _industryRepository.IndustryExistsAsync(industryId);
        }

        public async Task<bool> IndustryNameExistsAsync(string name, int? excludeId = null)
        {
            return await _industryRepository.IndustryNameExistsAsync(name, excludeId);
        }
    }
}
