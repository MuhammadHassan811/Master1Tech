using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.Industry;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Mapping.IndustryMapping
{
    public class IndustryMappingService : IIndustryMappingService
    {
        public IndustryDto MapToIndustryDto(Master1Tech.Shared.Models.Industry industry)
        {
            return new IndustryDto
            {
                Id = industry.Id,
                Name = industry.Name,
                Description = industry.Description
            };
        }

        public Master1Tech.Shared.Models.Industry MapToIndustryEntity(IndustryCreateDto industryCreateDto)
        {
            return new Master1Tech.Shared.Models.Industry
            {
                Name = industryCreateDto.Name,
                Description = industryCreateDto.Description
            };
        }

        public Master1Tech.Shared.Models.Industry MapToIndustryEntity(IndustryUpdateDto industryUpdateDto)
        {
            return new Master1Tech.Shared.Models.Industry
            {
                Id = industryUpdateDto.Id,
                Name = industryUpdateDto.Name,
                Description = industryUpdateDto.Description
            };
        }

        public PagedResultDto<IndustryDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.Industry> pagedResult)
        {
            return new PagedResultDto<IndustryDto>
            {
                Results = pagedResult.Results.Select(MapToIndustryDto).ToList(),
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
