using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Master1Tech.Server.Models
{
    public class IndustryRepository : IIndustryRepository
    {
        private readonly AppDbContext _appDbContext;

        public IndustryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Industry> AddIndustryAsync(Industry industry)
        {
            var result = await _appDbContext.Industries.AddAsync(industry);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Industry?> DeleteIndustryAsync(int industryId)
        {
            var result = await _appDbContext.Industries.FirstOrDefaultAsync(i => i.Id == industryId);
            if (result != null)
            {
                _appDbContext.Industries.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Industry?> GetIndustryAsync(int industryId)
        {
            return await _appDbContext.Industries.FirstOrDefaultAsync(i => i.Id == industryId);
        }

        public PagedResult<Industry> GetIndustries(string? name, int page)
        {
            int pageSize = 10;

            var query = _appDbContext.Industries.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(i => i.Name != null && i.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
            }

            return query.OrderBy(i => i.Name)
                       .GetPaged(page, pageSize);
        }

        public async Task<Industry?> UpdateIndustryAsync(Industry industry)
        {
            var result = await _appDbContext.Industries.FirstOrDefaultAsync(i => i.Id == industry.Id);
            if (result != null)
            {
                _appDbContext.Entry(result).CurrentValues.SetValues(industry);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<bool> IndustryExistsAsync(int industryId)
        {
            return await _appDbContext.Industries.AnyAsync(i => i.Id == industryId);
        }

        public async Task<bool> IndustryNameExistsAsync(string name, int? excludeId = null)
        {
            var query = _appDbContext.Industries.Where(i => i.Name == name);

            if (excludeId.HasValue)
            {
                query = query.Where(i => i.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }
        public async Task<List<Industry>> GetAllIndustry()
        {
            return await _appDbContext.Industries
                .OrderBy(t => t.Id)
                .ToListAsync();
        }
    }
}