using Master1Tech.DTOs.Company;
using Master1Tech.Models;
using Master1Tech.Shared.Data;

namespace Master1Tech.Services
{
    public interface ICompanyService
    {
        Task<PagedResult<CompanyDto>> GenerateSampleCompanies(CompanyFilter filter, int page, int pageSize);
        Task<Company?> GetCompanyByIdAsync(int id);
        Task<Company?> GetCompanyBySlugAsync(string slug);
        Task AddCompany(Company company);
    }
}
