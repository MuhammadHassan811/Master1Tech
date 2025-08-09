using Master1Tech.Server.Authorization;
using Master1Tech.Server.Models;
using Master1Tech.Server.Services.Industry;
using Master1Tech.Shared.DTOs.Industry;
using Master1Tech.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Master1Tech.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IndustryController : ControllerBase
    {
        private readonly IIndustryService _industryService;

        public IndustryController(IIndustryService industryService)
        {
            _industryService = industryService;
        }

        /// <summary>
        /// Returns a list of paginated people with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetIndustry([FromQuery] string? name, int page)
        {
            return Ok(_industryService.GetIndustries(name, page));
        }

        /// <summary>
        /// Gets a specific Industry by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetIndustry(int id)
        {
            return Ok(await _industryService.GetIndustryAsync(id));
        }

        /// <summary>
        /// Creates a Industry with child addresses.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddIndustry(IndustryCreateDto industryCreateDto)
        {
            return Ok(await _industryService.AddIndustryAsync(industryCreateDto));
        }
        
        /// <summary>
        /// Updates a Industry with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateIndustry(int id, IndustryUpdateDto industryUpdateDto)
        {
            if (id != industryUpdateDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedIndustry = await _industryService.UpdateIndustryAsync(industryUpdateDto);
                if (updatedIndustry == null)
                {
                    return NotFound($"Industry with ID {id} not found");
                }

                return Ok(updatedIndustry);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
           
        }

        /// <summary>
        /// Deletes a Industry with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIndustry(int id)
        {
            return Ok(await _industryService.DeleteIndustryAsync(id));
        }
    }
}
