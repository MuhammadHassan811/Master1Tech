using Master1Tech.Models;
using Master1Tech.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace Master1Tech.Server.Models
{
    public class CompanyRepository : ICompanyRepository
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


        public PagedResult<Company> GetCompaniesFromDatabase(
        string? location = null,
        string? services = null,
        string? teamSize = null,
        string? hourlyRate = null,
        string? sortBy = null,
        int page = 1,
        int pageSize = 12)
        {


            var query = _appDbContext.Companies/*.Include(x => x.CompanyServices).ThenInclude(cs => cs.Service)*/.AsQueryable();

            if (!string.IsNullOrEmpty(location))
                query = query.Where(c => c.Headquarter != null && c.Headquarter.ToLower().StartsWith(location.ToLower(), StringComparison.OrdinalIgnoreCase));

            // If you have a real Services property, adjust this filter accordingly
            //if (!string.IsNullOrEmpty(services))
            //    query = query.Where(c => c.CompanyServices.Any(cs => cs.Service.Name.Contains(services, StringComparison.OrdinalIgnoreCase)));

            if (!string.IsNullOrEmpty(teamSize))
                query = query.Where(c => c.TeamSize == teamSize);

            if (!string.IsNullOrEmpty(hourlyRate))
                query = query.Where(c => c.HourlyRate == hourlyRate);

            query = sortBy?.ToLower() switch
            {
                "name" => query.OrderBy(c => c.Name),
                "rating" => query.OrderByDescending(c => c.Rating),
                "teamsize" => query.OrderBy(c => c.TeamSize),
                _ => query.OrderBy(c => c.Id)
            };

            return query.GetPaged(page, pageSize);
            //string? name = string.Empty;

            //if (page < 1) page = 1;

            //if (!string.IsNullOrEmpty(name))
            //{
            //    return _appDbContext.Companies
            //        .Where(p => p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
            //    //.Include(c => c.CompanyServices)
            //    //    .ThenInclude(cs => cs.Service)
            //    //.Include(c => c.CompanyCategories)
            //    //    .ThenInclude(cc => cc.Category)
            //    //.Include(c => c.Technologies)
            //    //    .ThenInclude(ct => ct.Technology)
            //    //.Include(c => c.Reviews)
            //    //.Include(c => c.Contacts)
            //    //.Include(c => c.Projects)
            //    //.Include(c => c.TeamMembers)
            //    //.Include(c => c.Locations)
            //    .GetPaged(page, pageSize);
            //}
            //else
            //{
            //    IQueryable<Company> query = _appDbContext.Companies;
            //    return query.GetPaged(page, pageSize);
            //    //return _appDbContext.Companies.GetPaged(page, pageSize);
            //}
            ////    else
            ////    {
            ////        return _appDbContext.Companies
            ////        .Include(c => c.CompanyServices)
            ////            .ThenInclude(cs => cs.Service)
            ////        .Include(c => c.CompanyCategories)
            ////            .ThenInclude(cc => cc.Category)
            ////        .Include(c => c.Technologies)
            ////            .ThenInclude(ct => ct.Technology)
            ////        .Include(c => c.Reviews)
            ////        .Include(c => c.Contacts)
            ////        .Include(c => c.Projects)
            ////        .Include(c => c.TeamMembers)
            ////        .Include(c => c.Locations)
            ////                .GetPaged(page, pageSize);
            ////    }
            //return new PagedResult<Company>();
        }

        public async Task<Company?> GetCompaniesById(int id)
        {


            var company = await _appDbContext.Companies
               .Where(c => c.Id == id)
               .Include(x => x.CompanyServices).ThenInclude(x => x.Service)
               .Include(x => x.FirstAnswerQuestions)
               .Include(x => x.CompanyTechnologies)
                    .ThenInclude(x => x.Technology)
               .Include(x => x.CompanyIndustryFocus)
                    .ThenInclude(x => x.Industry)
               .FirstOrDefaultAsync();

            //        var company = await _appDbContext.Companies
            //.Where(c => c.Id == id)
            //.Select(c => new CompanyDTO
            //{
            //    Name = c.Name,
            //    Description = c.Description,
            //    TeamSize = c.TeamSize,
            //    Headquarter = c.Headquarter,
            //    HourlyRate = c.HourlyRate,
            //    IsVerified = c.IsVerified,
            //    FoundedYear = c.FoundedYear,
            //    WebsiteURL = c.WebsiteURL//,
            //    //Services = string.Join(", ", c.CompanyServices
            //    //                              .Select(cs => cs.Service.Name)
            //    //                             .Distinct()) // stays as IQueryable
            //}).AsNoTracking()
            //.FirstOrDefaultAsync();

            return company;
            //return new CompanyDTO
            //{
            //    Name = company.Name,
            //    Description = company.Description,
            //    TeamSize = company.TeamSize,
            //    Headquarter = company.Headquarter,
            //    HourlyRate = company.HourlyRate,
            //    IsVerified = company.IsVerified,
            //    FoundedYear = company.FoundedYear,
            //    WebsiteURL = company.WebsiteURL,
            //    Services = company.Services
            //};

        }
        public async Task<Company?> GetCompaniesBySlug(string slug)
        {


            var company = await _appDbContext.Companies
               .Where(c => c.Slug == slug)
               .Include(x => x.CompanyServices).ThenInclude(x => x.Service)
               .Include(x => x.FirstAnswerQuestions)
               .Include(x => x.CompanyTechnologies)
                    .ThenInclude(x => x.Technology)
               .Include(x => x.CompanyIndustryFocus)
                    .ThenInclude(x => x.Industry)
               .FirstOrDefaultAsync();

            //        var company = await _appDbContext.Companies
            //.Where(c => c.Id == id)
            //.Select(c => new CompanyDTO
            //{
            //    Name = c.Name,
            //    Description = c.Description,
            //    TeamSize = c.TeamSize,
            //    Headquarter = c.Headquarter,
            //    HourlyRate = c.HourlyRate,
            //    IsVerified = c.IsVerified,
            //    FoundedYear = c.FoundedYear,
            //    WebsiteURL = c.WebsiteURL//,
            //    //Services = string.Join(", ", c.CompanyServices
            //    //                              .Select(cs => cs.Service.Name)
            //    //                             .Distinct()) // stays as IQueryable
            //}).AsNoTracking()
            //.FirstOrDefaultAsync();

            return company;
            //return new CompanyDTO
            //{
            //    Name = company.Name,
            //    Description = company.Description,
            //    TeamSize = company.TeamSize,
            //    Headquarter = company.Headquarter,
            //    HourlyRate = company.HourlyRate,
            //    IsVerified = company.IsVerified,
            //    FoundedYear = company.FoundedYear,
            //    WebsiteURL = company.WebsiteURL,
            //    Services = company.Services
            //};

        }

    }
}