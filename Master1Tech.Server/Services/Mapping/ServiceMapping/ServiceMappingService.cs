using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.Service;
using Master1Tech.Shared.DTOs;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Services.Mapping.ServiceMapping
{
    public class ServiceMappingService : IServiceMappingService
    {
        public ServiceDto MapToServiceDto(Master1Tech.Shared.Models.Service service, int companyCount = 0)
        {
            return new ServiceDto
            {
                ServiceID = service.ServiceID,
                Name = service.Name,
                Description = service.Description,
                CompanyCount = companyCount
            };
        }

        public ServiceSummaryDto MapToServiceSummaryDto(Master1Tech.Shared.Models.Service service)
        {
            return new ServiceSummaryDto
            {
                ServiceID = service.ServiceID,
                Name = service.Name,
                Description = service.Description,
                Category = service.Category ?? string.Empty
            };
        }

        public Master1Tech.Shared.Models.Service MapToServiceEntity(ServiceCreateDto serviceCreateDto)
        {
            return new Master1Tech.Shared.Models.Service
            {
                Name = serviceCreateDto.Name,
                Description = serviceCreateDto.Description,
                CompanyServices = new List<CompaniesService>()
            };
        }

        public Master1Tech.Shared.Models.Service MapToServiceEntity(ServiceUpdateDto serviceUpdateDto)
        {
            return new Master1Tech.Shared.Models.Service
            {
                ServiceID = serviceUpdateDto.ServiceID,
                Name = serviceUpdateDto.Name,
                Description = serviceUpdateDto.Description,
                CompanyServices = new List<CompaniesService>()
            };
        }

        public PagedResultDto<ServiceDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.Service> pagedResult)
        {
            return new PagedResultDto<ServiceDto>
            {
                Results = pagedResult.Results.Select(s => MapToServiceDto(s)).ToList(),
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
