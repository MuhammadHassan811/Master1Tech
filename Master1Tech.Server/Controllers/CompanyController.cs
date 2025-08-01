using Master1Tech.Models;
using Master1Tech.Server.Authorization;
using Master1Tech.Server.Models;
using Master1Tech.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Master1Tech.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _CompanyRepository;

        public CompanyController(ICompanyRepository CompanyRepository)
        {
            _CompanyRepository = CompanyRepository;
        }

        /// <summary>
        /// Returns a list of paginated people with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetCompaniesFromDatabase()
        {
            try
            {
                var companies = _CompanyRepository.GetCompaniesFromDatabase();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                // Log the error if you have logging configured
                // _logger.LogError(ex, "Error fetching companies");
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetCompaniesById(int id)
        {
            try
            {
                var companies = _CompanyRepository.GetCompaniesById(id);
                if (companies == null)
                    return NotFound();

                return Ok(companies); // return the actual object
            }
            catch (Exception ex)
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

        ///// <summary>
        ///// Creates a Company with child addresses.
        ///// </summary>
        //[HttpPost]
        //public async Task<ActionResult> AddCompany(Company Company)
        //{
        //    return Ok(await _CompanyRepository.AddCompany(Company));
        //}

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
