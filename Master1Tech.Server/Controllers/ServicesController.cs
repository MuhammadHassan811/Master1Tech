using Master1Tech.Server.Authorization;
using Master1Tech.Server.Models;
using Master1Tech.Server.Services.Industry;
using Master1Tech.Server.Services.Service;
using Master1Tech.Shared.DTOs.Industry;
using Master1Tech.Shared.DTOs.Service;
using Master1Tech.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Master1Tech.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        /// <summary>
        /// Returns a list of paginated people with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetServices([FromQuery] string? name, int page)
        {
            return Ok(_serviceService.GetServices(name, page));
        }

        /// <summary>
        /// Gets a specific Industry by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetService(int id)
        {
            return Ok(await _serviceService.GetServiceAsync(id));
        }

        /// <summary>
        /// Creates a Industry with child addresses.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddService(ServiceCreateDto serviceCreateDto)
        {
            return Ok(await _serviceService.AddServiceAsync(serviceCreateDto));
        }
        
        /// <summary>
        /// Updates a Industry with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateIndustry(int id, ServiceUpdateDto serviceUpdateDto)
        {
            if (id != serviceUpdateDto.ServiceID)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedIndustry = await _serviceService.UpdateServiceAsync(serviceUpdateDto);
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
        /// Deletes a Service with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            return Ok(await _serviceService.DeleteServiceAsync(id));
        }

    }
}
