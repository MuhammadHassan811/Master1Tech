using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.Industry;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Mapping.IndustryMapping
{
    public interface IIndustryMappingService
    {
        IndustryDto MapToIndustryDto(Master1Tech.Shared.Models.Industry industry);
        Master1Tech.Shared.Models.Industry MapToIndustryEntity(IndustryCreateDto industryCreateDto);
        Master1Tech.Shared.Models.Industry MapToIndustryEntity(IndustryUpdateDto industryUpdateDto);
        PagedResultDto<IndustryDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.Industry> pagedResult);
    }
}
