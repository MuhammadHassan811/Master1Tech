using Master1Tech.Models;
using Master1Tech.Server.Authorization;
using Master1Tech.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Master1Tech.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _CompanyRepository;
        private readonly ILogger<CompanyController> _logger;
        public CompanyController(ICompanyRepository CompanyRepository, ILogger<CompanyController> logger)
        {
            _CompanyRepository = CompanyRepository;
            _logger = logger;
        }

        /// <summary>
        /// Returns a list of paginated people with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<ActionResult> GetCompaniesFromDatabase(
            [FromQuery] CompanyFilter filter,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 12)
        {
            try
            {
                var companies = await _CompanyRepository.GetCompaniesFromDatabase(filter, page, pageSize);
                return Ok(companies);
            }
            catch (Exception ex)
            {
                // Log the error if you have logging configured
                _logger.LogError(ex, "Error fetching companies");
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompaniesById(int id)
        {
            try
            {
                var companies = await _CompanyRepository.GetCompaniesById(id);
                if (companies == null)
                    return NotFound();

                return Ok(companies); // return the actual object
            }
            catch (Exception)
            {
                // Log the error if you have logging configured
                // _logger.LogError(ex, "Error fetching companies");
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("get/{slug}")]
        public async Task<ActionResult> GetCompanyBySlug(string slug)
        {
            try
            {
                Master1Tech.Models.Company? companies = await _CompanyRepository.GetCompaniesBySlug(slug);
                if (companies == null)
                    return NotFound();

                return Ok(companies); // return the actual object
            }
            catch (Exception)
            {
                // Log the error if you have logging configured
                // _logger.LogError(ex, "Error fetching companies");
                return StatusCode(500, "Internal server error");
            }
        }



        ///// <summary>
        ///// Gets a specific Company by Id.
        ///// </summary>
        //[AllowAnonymous]
        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetCompany(int id)
        //{
        //    return Ok(await _CompanyRepository.GetCompany(id));
        //}

        /// <summary>
        /// Creates a Company with child addresses.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<ActionResult> AddCompany(Company Company)
        {
            //await _CompanyRepository.AddCompany(Company)
            return Ok();
        }

        ///// <summary>
        ///// Updates a Company with a specific Id.
        ///// </summary>
        //[HttpPut]
        //public async Task<ActionResult> UpdateCompany(Company Company)
        //{
        //    return Ok(await _CompanyRepository.UpdateCompany(Company));
        //}

        ///// <summary>
        ///// Deletes a Company with a specific Id.
        ///// </summary>
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteCompany(int id)
        //{
        //    return Ok(await _CompanyRepository.DeleteCompany(id));
        //}
    }
}
