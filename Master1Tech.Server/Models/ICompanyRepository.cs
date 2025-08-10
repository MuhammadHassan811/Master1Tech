using Master1Tech.DTOs.Company;
using Master1Tech.Models;
using Master1Tech.Shared.Data;

namespace Master1Tech.Server.Models
{
    public interface ICompanyRepository
    {
        //PagedResult<Company> GetPeople(string? name, int page);
        Task<PagedResult<CompanyDto>> GetCompaniesFromDatabase(
         CompanyFilter filter,
        int page = 1,
        int pageSize = 12);
        Task<Company?> GetCompaniesById(int id);
        Task<Company?> GetCompaniesBySlug(string slug);
        //Task<Company> AddCompany(Company Company);
        //Task<Company?> UpdateCompany(Company Company);
        //Task<Company?> DeleteCompany(int CompanyId);
    }
}