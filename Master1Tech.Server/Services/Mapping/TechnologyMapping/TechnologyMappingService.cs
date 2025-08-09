using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.Technology;
using Master1Tech.Shared.DTOs;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Services.Mapping.TechnologyMapping
{
    public class TechnologyMappingService : ITechnologyMappingService
    {
        public TechnologyDto MapToTechnologyDto(Master1Tech.Shared.Models.Technology technology, int companyCount = 0)
        {
            return new TechnologyDto
            {
                TechnologyID = technology.TechnologyID,
                Name = technology.Name,
                Description = technology.Description,
                Category = technology.Category,
                CompanyCount = companyCount
            };
        }

        public TechnologySummaryDto MapToTechnologySummaryDto(Master1Tech.Shared.Models.Technology technology)
        {
            return new TechnologySummaryDto
            {
                TechnologyID = technology.TechnologyID,
                Name = technology.Name,
                Category = technology.Category
            };
        }

        public Master1Tech.Shared.Models.Technology MapToTechnologyEntity(TechnologyCreateDto technologyCreateDto)
        {
            return new Master1Tech.Shared.Models.Technology
            {
                Name = technologyCreateDto.Name,
                Description = technologyCreateDto.Description,
                Category = technologyCreateDto.Category,
                CompanyTechnologies = new List<CompanyTechnology>()
            };
        }

        public Master1Tech.Shared.Models.Technology MapToTechnologyEntity(TechnologyUpdateDto technologyUpdateDto)
        {
            return new Master1Tech.Shared.Models.Technology
            {
                TechnologyID = technologyUpdateDto.TechnologyID,
                Name = technologyUpdateDto.Name,
                Description = technologyUpdateDto.Description,
                Category = technologyUpdateDto.Category,
                CompanyTechnologies = new List<CompanyTechnology>()
            };
        }

        public PagedResultDto<TechnologyDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.Technology> pagedResult)
        {
            return new PagedResultDto<TechnologyDto>
            {
                Results = pagedResult.Results.Select(t => MapToTechnologyDto(t)).ToList(),
                CurrentPage = pagedResult.CurrentPage,
                PageCount = pagedResult.PageCount,
                PageSize = pagedResult.PageSize,
                RowCount = pagedResult.RowCount,
                FirstRowOnPage = pagedResult.FirstRowOnPage,
                LastRowOnPage = pagedResult.LastRowOnPage
            };
        }
    }
}
