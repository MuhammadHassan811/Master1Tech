using Master1Tech.DTOs.Company;
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

        public async Task<PagedResult<CompanyDto>> GetCompaniesFromDatabase(
        CompanyFilter filter,
        int page = 1,
        int pageSize = 12)
        {


            // Start with a base IQueryable.
            var query = _appDbContext.Companies.AsQueryable();

            // Apply filters based on the filter object.
            if (filter.Services != null && filter.Services.Any())
                query = query.Where(c => c.CompanyServices.Any(cs => filter.Services.Contains(cs.ServiceID)));

            // Corrected the typo from "Techlogogies" to "Technologies"
            if (filter.Technologies != null && filter.Technologies.Any())
                query = query.Where(c => c.CompanyTechnologies.Any(ct => filter.Technologies.Contains(ct.TechnologyID)));

            if (filter.Industries != null && filter.Industries.Any())
                query = query.Where(c => c.CompanyIndustryFocus.Any(ci => filter.Industries.Contains(ci.IndustryID)));

            if (filter.Year != null && filter.Year.Any())
                query = query.Where(c => filter.Year.Contains(c.FoundedYear));

            // Apply sorting using a more concise switch expression (C# 8+).
            query = (filter.SortBy?.ToLower()) switch
            {
                "name" => query.OrderBy(c => c.Name),
                "team size" => query.OrderByDescending(c => c.TeamSizeMin),
                "rating" => query.OrderByDescending(c => c.Rating),
                // A default sort order is crucial for consistent pagination.
                _ => query.OrderBy(c => c.Id)
            };

            // First, get the total count of items that match the filter for pagination metadata.
            // This executes a fast `COUNT(*)` query in the database.
            var totalRowCount = await query.CountAsync();
            var totalTableRowCount = await _appDbContext.Companies.CountAsync();
            // Now, apply pagination to the query.
            var results = await query.Skip((page - 1) * pageSize)
                                     .Take(pageSize)
                                     .Select(c => new CompanyDto
                                     {
                                         Id = c.Id,
                                         Name = c.Name,
                                         Description = c.Description,
                                         Location = c.Location,
                                         Country = c.Country,
                                         LogoUrl = c.LogoUrl,
                                         TeamSize = c.TeamSize,
                                         Headquarter = c.Headquarter,
                                         HourlyRate = c.HourlyRate,
                                         Rating = c.Rating,
                                         IsVerified = c.IsVerified,
                                         LogoText = c.LogoText,
                                         LogoColor = c.LogoColor,
                                         EmployeesCount = c.EmployeesCount,
                                         FoundedYear = c.FoundedYear,
                                         WebsiteURL = c.WebsiteURL,
                                         Slug = c.Slug,
                                         DateAdded = c.DateAdded,
                                         LastUpdated = c.LastUpdated
                                     }).ToListAsync();

            // Construct the final paged result.
            return new PagedResult<CompanyDto>
            {
                Results = results,
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = totalRowCount,
                TotalRowCount = totalTableRowCount,
                PageCount = (int)Math.Ceiling((double)totalRowCount / pageSize)
            };
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

            return company;
           

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

            return company;

        }

    }
}