using Master1Tech.DTOs.Company;
using Master1Tech.Models;
using Master1Tech.Shared.Data;

namespace Master1Tech.Services
{
    public interface ICompanyService
    {
        //Task<int> GetTotalCompaniesAsync(CompanyFilter? filter = null);
        // Task<PagedResult<Company>> GetCompaniesAsync(CompanyFilter? filter = null, int page = 1, int pageSize = 9);
        Task<PagedResult<CompanyDto>> GenerateSampleCompanies(CompanyFilter filter, int page, int pageSize);
        Task<Company?> GetCompanyByIdAsync(int id);
        Task<Company?> GetCompanyBySlugAsync(string slug);

        //Task<PagedResult<Company>> GetCompaniesAsync(string? name, int page);
        //Task<int> GetCompanyCountAsync(string name, string page);
    }
}
