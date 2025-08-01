using Master1Tech.Models;
using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Models
{
    public interface ICompanyRepository
    {
        //PagedResult<Company> GetPeople(string? name, int page);
        PagedResult<Company> GetCompaniesFromDatabase();
        Company GetCompaniesById(int id);
        //Task<Company> AddCompany(Company Company);
        //Task<Company?> UpdateCompany(Company Company);
        //Task<Company?> DeleteCompany(int CompanyId);
    }
}