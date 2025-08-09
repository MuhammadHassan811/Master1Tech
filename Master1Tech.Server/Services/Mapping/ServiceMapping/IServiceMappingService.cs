using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.Service;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Mapping.ServiceMapping
{
    public interface IServiceMappingService
    {
        ServiceDto MapToServiceDto(Master1Tech.Shared.Models.Service service, int companyCount = 0);
        ServiceSummaryDto MapToServiceSummaryDto(Master1Tech.Shared.Models.Service service);
        Master1Tech.Shared.Models.Service MapToServiceEntity(ServiceCreateDto serviceCreateDto);
        Master1Tech.Shared.Models.Service MapToServiceEntity(ServiceUpdateDto serviceUpdateDto);
        PagedResultDto<ServiceDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.Service> pagedResult);
    }
}
