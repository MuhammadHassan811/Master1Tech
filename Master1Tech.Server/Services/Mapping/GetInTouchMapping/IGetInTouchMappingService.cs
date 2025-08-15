using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.GetInTouch;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Mapping.GetInTouchMapping
{
    public interface IGetInTouchMappingService
    {
        GetInTouchDto MapToGetInTouchDto(Master1Tech.Shared.Models.GetInTouch getInTouch);
        GetInTouchSummaryDto MapToGetInTouchSummaryDto(Master1Tech.Shared.Models.GetInTouch getInTouch);
        Master1Tech.Shared.Models.GetInTouch MapToGetInTouchEntity(GetInTouchCreateDto getInTouchCreateDto);
        Master1Tech.Shared.Models.GetInTouch MapToGetInTouchEntity(GetInTouchUpdateDto getInTouchUpdateDto);
        PagedResultDto<GetInTouchDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.GetInTouch> pagedResult);
    }
}
