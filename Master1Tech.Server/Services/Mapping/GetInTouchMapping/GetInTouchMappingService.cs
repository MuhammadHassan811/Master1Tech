using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.GetInTouch;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Mapping.GetInTouchMapping
{
    public class GetInTouchMappingService : IGetInTouchMappingService
    {
        public GetInTouchDto MapToGetInTouchDto(Master1Tech.Shared.Models.GetInTouch getInTouch)
        {
            return new GetInTouchDto
            {
                Id = getInTouch.Id,
                FullName = getInTouch.FullName,
                Email = getInTouch.Email,
                PhoneNo = getInTouch.PhoneNo,
                CompanyName = getInTouch.CompanyName,
                JobTitle = getInTouch.JobTitle,
                ServiceId = getInTouch.ServiceId,
                ServiceDisplayName = getInTouch.Service?.Name,
                ProjectDescription = getInTouch.ProjectDescription,
                GetVettedCompanies = getInTouch.GetVettedCompanies,
                FilePath = getInTouch.FilePath,
                FileName = getInTouch.FileName,
                CompanyId = getInTouch.CompanyId,
                CompanyDisplayName = getInTouch.Company?.Name, // Assuming Company has a Name property
                Status = getInTouch.Status,
                DateAdded = getInTouch.DateAdded,
                DateUpdated = getInTouch.DateUpdated,
                IsCompleted = getInTouch.IsCompleted
            };
        }

        public GetInTouchSummaryDto MapToGetInTouchSummaryDto(Master1Tech.Shared.Models.GetInTouch getInTouch)
        {
            return new GetInTouchSummaryDto
            {
                Id = getInTouch.Id,
                FullName = getInTouch.FullName,
                Email = getInTouch.Email,
                CompanyName = getInTouch.CompanyName,
                Service = getInTouch.Service.ServiceID,
                Status = getInTouch.Status,
                IsCompleted = getInTouch.IsCompleted,
                DateAdded = getInTouch.DateAdded
            };
        }

        public Master1Tech.Shared.Models.GetInTouch MapToGetInTouchEntity(GetInTouchCreateDto getInTouchCreateDto)
        {
            return new Master1Tech.Shared.Models.GetInTouch
            {
                FullName = getInTouchCreateDto.FullName,
                Email = getInTouchCreateDto.Email,
                PhoneNo = getInTouchCreateDto.PhoneNo,
                CompanyName = getInTouchCreateDto.CompanyName,
                JobTitle = getInTouchCreateDto.JobTitle,
                ServiceId = getInTouchCreateDto.ServiceId,
                ProjectDescription = getInTouchCreateDto.ProjectDescription,
                GetVettedCompanies = getInTouchCreateDto.GetVettedCompanies,
                FilePath = null, 
                FileName = null, 
                CompanyId = getInTouchCreateDto.CompanyId,
                Status = false, // Default to false for new requests
                IsCompleted = false, // Default to false for new requests
                DateAdded = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
        }

        public Master1Tech.Shared.Models.GetInTouch MapToGetInTouchEntity(GetInTouchUpdateDto getInTouchUpdateDto)
        {
            return new Master1Tech.Shared.Models.GetInTouch
            {
                Id = getInTouchUpdateDto.Id,
                FullName = getInTouchUpdateDto.FullName,
                Email = getInTouchUpdateDto.Email,
                PhoneNo = getInTouchUpdateDto.PhoneNo,
                CompanyName = getInTouchUpdateDto.CompanyName,
                JobTitle = getInTouchUpdateDto.JobTitle,
                ServiceId = getInTouchUpdateDto.ServiceId,
                ProjectDescription = getInTouchUpdateDto.ProjectDescription,
                GetVettedCompanies = getInTouchUpdateDto.GetVettedCompanies,
                FilePath = getInTouchUpdateDto.FilePath,
                CompanyId = getInTouchUpdateDto.CompanyId,
                DateUpdated = DateTime.UtcNow
            };
        }

        public PagedResultDto<GetInTouchDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.GetInTouch> pagedResult)
        {
            return new PagedResultDto<GetInTouchDto>
            {
                Results = pagedResult.Results.Select(MapToGetInTouchDto).ToList(),
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
