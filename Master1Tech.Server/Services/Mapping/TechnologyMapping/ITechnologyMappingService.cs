using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.Technology;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Mapping.TechnologyMapping
{
    public interface ITechnologyMappingService
    {
        TechnologyDto MapToTechnologyDto(Master1Tech.Shared.Models.Technology technology, int companyCount = 0);
        TechnologySummaryDto MapToTechnologySummaryDto(Master1Tech.Shared.Models.Technology technology);
        Master1Tech.Shared.Models.Technology MapToTechnologyEntity(TechnologyCreateDto technologyCreateDto);
        Master1Tech.Shared.Models.Technology MapToTechnologyEntity(TechnologyUpdateDto technologyUpdateDto);
        PagedResultDto<TechnologyDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.Technology> pagedResult);
    }
}
