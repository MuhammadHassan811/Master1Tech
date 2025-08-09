using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Master1Tech.Server.Models
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly AppDbContext _appDbContext;

        public TechnologyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Technology> AddTechnologyAsync(Technology technology)
        {
            var result = await _appDbContext.Technologies.AddAsync(technology);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Technology?> DeleteTechnologyAsync(int technologyId)
        {
            var result = await _appDbContext.Technologies.FirstOrDefaultAsync(t => t.TechnologyID == technologyId);
            if (result != null)
            {
                // Check if technology is being used by any companies
                var hasCompanies = await _appDbContext.CompanyTechnologies
                    .AnyAsync(ct => ct.TechnologyID == technologyId);

                if (hasCompanies)
                {
                    throw new InvalidOperationException("Cannot delete technology that is associated with companies. Please remove all company associations first.");
                }

                _appDbContext.Technologies.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Technology?> GetTechnologyAsync(int technologyId)
        {
            return await _appDbContext.Technologies.FirstOrDefaultAsync(t => t.TechnologyID == technologyId);
        }

        public async Task<Technology?> GetTechnologyWithCompaniesAsync(int technologyId)
        {
            return await _appDbContext.Technologies
                .Include(t => t.CompanyTechnologies)
                .FirstOrDefaultAsync(t => t.TechnologyID == technologyId);
        }

        public PagedResult<Technology> GetTechnologies(string? name, string? category, int page)
        {
            int pageSize = 10;

            var query = _appDbContext.Technologies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(t => t.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(t => t.Category.Contains(category, StringComparison.CurrentCultureIgnoreCase));
            }

            return query.OrderBy(t => t.Category)
                       .ThenBy(t => t.Name)
                       .GetPaged(page, pageSize);
        }

        public async Task<Technology?> UpdateTechnologyAsync(Technology technology)
        {
            var result = await _appDbContext.Technologies.FirstOrDefaultAsync(t => t.TechnologyID == technology.TechnologyID);
            if (result != null)
            {
                _appDbContext.Entry(result).CurrentValues.SetValues(technology);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<bool> TechnologyExistsAsync(int technologyId)
        {
            return await _appDbContext.Technologies.AnyAsync(t => t.TechnologyID == technologyId);
        }

        public async Task<bool> TechnologyNameExistsAsync(string name, int? excludeId = null)
        {
            var query = _appDbContext.Technologies.Where(t => t.Name == name);

            if (excludeId.HasValue)
            {
                query = query.Where(t => t.TechnologyID != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<List<Technology>> GetAllTechnologiesAsync()
        {
            return await _appDbContext.Technologies
                .OrderBy(t => t.Category)
                .ThenBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<List<Technology>> GetTechnologiesByCategoryAsync(string category)
        {
            return await _appDbContext.Technologies
                .Where(t => t.Category == category)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<List<string>> GetAllCategoriesAsync()
        {
            return await _appDbContext.Technologies
                .Select(t => t.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();
        }

        public async Task<int> GetCompanyCountForTechnologyAsync(int technologyId)
        {
            return await _appDbContext.CompanyTechnologies
                .Where(ct => ct.TechnologyID == technologyId)
                .CountAsync();
        }
    }
}
