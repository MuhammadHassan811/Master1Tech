using Master1Tech.Server.Models;
using Master1Tech.Shared.DTOs.GetInTouch;
using Master1Tech.Shared.DTOs;
using Master1Tech.Server.Services.Mapping.GetInTouchMapping;
using Master1Tech.Server.Services.FileService;

namespace Master1Tech.Server.Services.GetInTouch
{
    public class GetInTouchService : IGetInTouchService
    {
        private readonly IGetInTouchRepository _getInTouchRepository;
        private readonly IGetInTouchMappingService _mappingService;
        private readonly IFileService _fileService;

        public GetInTouchService(IGetInTouchRepository getInTouchRepository, IGetInTouchMappingService mappingService, IFileService fileService)
        {
            _getInTouchRepository = getInTouchRepository;
            _mappingService = mappingService;
            _fileService = fileService;
        }

        public PagedResultDto<GetInTouchDto> GetGetInTouchRequests(string? email, bool? status, bool? isCompleted, int? service, int page)
        {
            var result = _getInTouchRepository.GetGetInTouchRequests(email, status, isCompleted, service, page);
            return _mappingService.MapToPagedResultDto(result);
        }

        public async Task<GetInTouchDto?> GetGetInTouchAsync(int id)
        {
            var getInTouch = await _getInTouchRepository.GetGetInTouchAsync(id);
            return getInTouch != null ? _mappingService.MapToGetInTouchDto(getInTouch) : null;
        }

        public async Task<GetInTouchDto?> GetGetInTouchWithCompanyAsync(int id)
        {
            var getInTouch = await _getInTouchRepository.GetGetInTouchWithCompanyAsync(id);
            return getInTouch != null ? _mappingService.MapToGetInTouchDto(getInTouch) : null;
        }

        public async Task<GetInTouchDto> AddGetInTouchAsync(GetInTouchCreateDto getInTouchCreateDto)
        {
            var getInTouch = _mappingService.MapToGetInTouchEntity(getInTouchCreateDto);
            if (getInTouchCreateDto.AttachmentFile != null && getInTouchCreateDto.AttachmentFile.Length > 0)
            {
                var fileResult = await _fileService.SaveFileAsync(getInTouchCreateDto.AttachmentFile, "getintouch");

                if (fileResult.Success)
                {
                    getInTouch.FilePath = fileResult.FilePath;
                    getInTouch.FileName = fileResult.FileName;
                }
                else
                {
                    throw new InvalidOperationException($"File upload failed: {fileResult.ErrorMessage}");
                }
            }
            var addedGetInTouch = await _getInTouchRepository.AddGetInTouchAsync(getInTouch);
            return _mappingService.MapToGetInTouchDto(addedGetInTouch);
        }

        public async Task<GetInTouchDto?> UpdateGetInTouchAsync(GetInTouchUpdateDto getInTouchUpdateDto)
        {
            // Check if request exists
            if (!await _getInTouchRepository.GetInTouchExistsAsync(getInTouchUpdateDto.Id))
            {
                return null;
            }

            var getInTouch = _mappingService.MapToGetInTouchEntity(getInTouchUpdateDto);
            var updatedGetInTouch = await _getInTouchRepository.UpdateGetInTouchAsync(getInTouch);
            return updatedGetInTouch != null ? _mappingService.MapToGetInTouchDto(updatedGetInTouch) : null;
        }

        public async Task<GetInTouchDto?> UpdateStatusAsync(GetInTouchStatusUpdateDto statusUpdateDto)
        {
            var updatedGetInTouch = await _getInTouchRepository.UpdateStatusAsync(
                statusUpdateDto.Id,
                statusUpdateDto.Status,
                statusUpdateDto.IsCompleted);

            return updatedGetInTouch != null ? _mappingService.MapToGetInTouchDto(updatedGetInTouch) : null;
        }

        public async Task<bool> DeleteGetInTouchAsync(int id)
        {
            var result = await _getInTouchRepository.DeleteGetInTouchAsync(id);
            return result != null;
        }

        public async Task<bool> GetInTouchExistsAsync(int id)
        {
            return await _getInTouchRepository.GetInTouchExistsAsync(id);
        }

        public async Task<List<GetInTouchSummaryDto>> GetPendingRequestsAsync()
        {
            var requests = await _getInTouchRepository.GetPendingRequestsAsync();
            return requests.Select(_mappingService.MapToGetInTouchSummaryDto).ToList();
        }

        public async Task<List<GetInTouchSummaryDto>> GetCompletedRequestsAsync()
        {
            var requests = await _getInTouchRepository.GetCompletedRequestsAsync();
            return requests.Select(_mappingService.MapToGetInTouchSummaryDto).ToList();
        }

        public async Task<List<GetInTouchSummaryDto>> GetRequestsByServiceAsync(int serviceId)
        {
            var requests = await _getInTouchRepository.GetRequestsByServiceAsync(serviceId);
            return requests.Select(_mappingService.MapToGetInTouchSummaryDto).ToList();
        }

        public async Task<Dictionary<string, int>> GetRequestStatisticsAsync()
        {
            var activeCount = await _getInTouchRepository.GetRequestCountByStatusAsync(true);
            var inactiveCount = await _getInTouchRepository.GetRequestCountByStatusAsync(false);
            var pendingRequests = await _getInTouchRepository.GetPendingRequestsAsync();
            var completedRequests = await _getInTouchRepository.GetCompletedRequestsAsync();

            return new Dictionary<string, int>
            {
                ["Active"] = activeCount,
                ["Inactive"] = inactiveCount,
                ["Pending"] = pendingRequests.Count,
                ["Completed"] = completedRequests.Count,
                ["Total"] = activeCount + inactiveCount
            };
        }
    }
}
