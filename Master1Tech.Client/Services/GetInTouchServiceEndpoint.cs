using Master1Tech.Client.Shared;
using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.GetInTouch;
using Master1Tech.Shared.DTOs.Technology;
using Master1Tech.Shared.Models;

namespace Master1Tech.Client.Services
{
    public class GetInTouchServiceEndpoint : IGetInTouchServiceEndpoint
    {
        private IHttpService _httpService;

        public GetInTouchServiceEndpoint(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<List<GetInTouchSummaryDto>> GetAllGetInTouchAsync()
        {
            var getintouch = await _httpService.Get<List<GetInTouchSummaryDto>>("api/GetInTouch/all");
            return getintouch ?? new List<GetInTouchSummaryDto>();
        }

        public async Task<PagedResult<GetInTouch>> GetInTouchAsync(string? name, int page)
        {
            return await _httpService.Get<PagedResult<GetInTouch>>("api/GetInTouch" + "?page=" + page + "&name=" + name);
        }

        public async Task<GetInTouchDto> GetGetInTouch(int id)
        {
            return await _httpService.Get<GetInTouchDto>($"api/GetInTouch/{id}");
        }

        public async Task DeleteGetInTouch(int id)
        {
            await _httpService.Delete($"api/GetInTouch/{id}");
        }

        public async Task AddGetInTouch(GetInTouch getInTouch)
        {
            await _httpService.Post($"api/GetInTouch", getInTouch);
        }

        public async Task UpdateGetInTouch(GetInTouch getInTouch)
        {
            await _httpService.Put($"api/GetInTouch", getInTouch);
        }
    }
}