using Master1Tech.Models;
using Master1Tech.Shared.Data;

namespace Master1Tech.Services
{
    public interface ICompanyService
    {
        Task<PagedResult<Company>> GetCompaniesAsync(string? name, int page);
        Task<int> GetCompanyCountAsync(string name, string page);
    }
}
