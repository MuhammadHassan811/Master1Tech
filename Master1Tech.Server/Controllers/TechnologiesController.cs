using Master1Tech.Server.Authorization;
using Master1Tech.Server.Models;
using Master1Tech.Server.Services.Industry;
using Master1Tech.Server.Services.Technology;
using Master1Tech.Shared.DTOs.Industry;
using Master1Tech.Shared.DTOs.Technology;
using Master1Tech.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Master1Tech.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TechnologiesController : ControllerBase
    {
        private readonly ITechnologyService _technologyService;

        public TechnologiesController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        /// <summary>
        /// Returns a list of paginated people with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("paged")]
        public ActionResult GetTechnology([FromQuery] string? name, string? category, int page)
        {
            return Ok(_technologyService.GetTechnologies(name, category, page));
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult> GetAllTechnology()
        {
            return Ok(await _technologyService.GetAllTechnologiesAsync());
        }


        /// <summary>
        /// Gets a specific Technology by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTechnology(int id)
        {
            return Ok(await _technologyService.GetTechnologyAsync(id));
        }

        /// <summary>
        /// Creates a Technolgy with child addresses.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddTechnology(TechnologyCreateDto technologyCreateDto)
        {
            return Ok(await _technologyService.AddTechnologyAsync(technologyCreateDto));
        }
        
        /// <summary>
        /// Updates a Technology with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateTechnology(int id, TechnologyUpdateDto technologyUpdateDto)
        {
            if (id != technologyUpdateDto.TechnologyID)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedIndustry = await _technologyService.UpdateTechnologyAsync(technologyUpdateDto);
                if (updatedIndustry == null)
                {
                    return NotFound($"Technology with ID {id} not found");
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
        public async Task<ActionResult> DeleteTechnology(int id)
        {
            return Ok(await _technologyService.DeleteTechnologyAsync(id));
        }
    }
}
