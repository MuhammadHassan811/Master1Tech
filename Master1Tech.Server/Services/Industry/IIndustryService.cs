using Master1Tech.Shared.DTOs.Industry;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Industry
{
    public interface IIndustryService
    {
        PagedResultDto<IndustryDto> GetIndustries(string? name, int page);
        Task<IndustryDto?> GetIndustryAsync(int industryId);
        Task<IndustryDto> AddIndustryAsync(IndustryCreateDto industryCreateDto);
        Task<IndustryDto?> UpdateIndustryAsync(IndustryUpdateDto industryUpdateDto);
        Task<bool> DeleteIndustryAsync(int industryId);
        Task<bool> IndustryExistsAsync(int industryId);
        Task<bool> IndustryNameExistsAsync(string name, int? excludeId = null);
        Task<List<IndustryDto>> GetAllIndustryAsync();
    }
}
