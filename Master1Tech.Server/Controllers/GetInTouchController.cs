using Master1Tech.Server.Services.GetInTouch;
using Master1Tech.Shared.DTOs.GetInTouch;
using Master1Tech.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Master1Tech.Server.Authorization;

namespace Master1Tech.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetInTouchController : ControllerBase
    {
        private readonly IGetInTouchService _getInTouchService;

        public GetInTouchController(IGetInTouchService getInTouchService)
        {
            _getInTouchService = getInTouchService;
        }

        [AllowAnonymous]
        [HttpGet("paged")]
        public ActionResult GetInTouchQuery([FromQuery] string? name, int page)
        {
            return Ok(_getInTouchService.GetInTouchQuery(name, page));
        }


        [HttpGet]
        public ActionResult<PagedResultDto<GetInTouchDto>> GetGetInTouchRequests(
            string? email,
            bool? status,
            bool? isCompleted,
            int? service,
            int page = 1)
        {
            var result = _getInTouchService.GetGetInTouchRequests(email, status, isCompleted, service, page);
            return Ok(result);
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<GetInTouchSummaryDto>>> GetAllRequests()
        {
            var requests = await _getInTouchService.GetAllRequestsAsync();
            return Ok(requests);
        }


        [HttpGet("pending")]
        public async Task<ActionResult<List<GetInTouchSummaryDto>>> GetPendingRequests()
        {
            var requests = await _getInTouchService.GetPendingRequestsAsync();
            return Ok(requests);
        }

        [HttpGet("completed")]
        public async Task<ActionResult<List<GetInTouchSummaryDto>>> GetCompletedRequests()
        {
            var requests = await _getInTouchService.GetCompletedRequestsAsync();
            return Ok(requests);
        }

        [HttpGet("by-service/{serviceId}")]
        public async Task<ActionResult<List<GetInTouchSummaryDto>>> GetRequestsByService(int serviceId)
        {
            var requests = await _getInTouchService.GetRequestsByServiceAsync(serviceId);
            return Ok(requests);
        }

        [HttpGet("statistics")]
        public async Task<ActionResult<Dictionary<string, int>>> GetRequestStatistics()
        {
            var statistics = await _getInTouchService.GetRequestStatisticsAsync();
            return Ok(statistics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetInTouchDto>> GetGetInTouch(int id)
        {
            var getInTouch = await _getInTouchService.GetGetInTouchAsync(id);
            if (getInTouch == null)
            {
                return NotFound($"GetInTouch request with ID {id} not found");
            }
            return Ok(getInTouch);
        }

        [HttpGet("{id}/with-company")]
        public async Task<ActionResult<GetInTouchDto>> GetGetInTouchWithCompany(int id)
        {
            var getInTouch = await _getInTouchService.GetGetInTouchWithCompanyAsync(id);
            if (getInTouch == null)
            {
                return NotFound($"GetInTouch request with ID {id} not found");
            }
            return Ok(getInTouch);
        }

        [HttpPost("submit")]
        public async Task<ActionResult<GetInTouchDto>> CreateGetInTouchRequest(GetInTouchCreateDto getInTouchCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            var createdGetInTouch = await _getInTouchService.AddGetInTouchAsync(getInTouchCreateDto);
            return CreatedAtAction(nameof(GetGetInTouch), new { id = createdGetInTouch.Id }, createdGetInTouch);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetInTouchDto>> UpdateGetInTouchRequest(int id, GetInTouchUpdateDto getInTouchUpdateDto)
        {
            if (id != getInTouchUpdateDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedGetInTouch = await _getInTouchService.UpdateGetInTouchAsync(getInTouchUpdateDto);
            if (updatedGetInTouch == null)
            {
                return NotFound($"GetInTouch request with ID {id} not found");
            }

            return Ok(updatedGetInTouch);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<GetInTouchDto>> UpdateStatus(int id, GetInTouchStatusUpdateDto statusUpdateDto)
        {
            if (id != statusUpdateDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedGetInTouch = await _getInTouchService.UpdateStatusAsync(statusUpdateDto);
            if (updatedGetInTouch == null)
            {
                return NotFound($"GetInTouch request with ID {id} not found");
            }

            return Ok(updatedGetInTouch);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGetInTouchRequest(int id)
        {
            return Ok(await _getInTouchService.DeleteGetInTouchAsync(id));
        }
    }
}
