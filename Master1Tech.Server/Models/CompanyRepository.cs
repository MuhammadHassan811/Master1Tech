using Master1Tech.Models;
using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Master1Tech.Server.Models
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly AppDbContext _appDbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //public PagedResult<Company> GetPeople(string? name, int page)
        //{
        //    int pageSize = 5;

        //    if (name != null)
        //    {
        //        return _appDbContext.People
        //            .Where(p => p.FirstName.Contains(name, StringComparison.CurrentCultureIgnoreCase) ||
        //                p.LastName.Contains(name, StringComparison.CurrentCultureIgnoreCase))
        //            .OrderBy(p => p.CompanyId)
        //            .Include(p => p.Addresses)
        //            .GetPaged(page, pageSize);
        //    }
        //    else
        //    {
        //        return _appDbContext.People
        //            .OrderBy(p => p.CompanyId)
        //            .Include(p => p.Addresses)
        //            .GetPaged(page, pageSize);
        //    }
        //}


        public PagedResult<Company> GetCompaniesFromDatabase(string? name, int page)
        {
            int pageSize = 6;

            if (name != null)
            {
                return _appDbContext.Companies
                    .Where(p => p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                .Include(c => c.CompanyServices)
                    .ThenInclude(cs => cs.Service)
                .Include(c => c.CompanyCategories)
                    .ThenInclude(cc => cc.Category)
                .Include(c => c.Technologies)
                    .ThenInclude(ct => ct.Technology)
                .Include(c => c.Reviews)
                .Include(c => c.Contacts)
                .Include(c => c.Projects)
                .Include(c => c.TeamMembers)
                .Include(c => c.Locations)
        .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.Companies
                .Include(c => c.CompanyServices)
                    .ThenInclude(cs => cs.Service)
                .Include(c => c.CompanyCategories)
                    .ThenInclude(cc => cc.Category)
                .Include(c => c.Technologies)
                    .ThenInclude(ct => ct.Technology)
                .Include(c => c.Reviews)
                .Include(c => c.Contacts)
                .Include(c => c.Projects)
                .Include(c => c.TeamMembers)
                .Include(c => c.Locations)
                        .GetPaged(page, pageSize);
            }

        }
    }
}