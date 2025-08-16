using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Master1Tech.Server.Models
{
    public class GetInTouchRepository : IGetInTouchRepository
    {
        private readonly AppDbContext _appDbContext;

        public GetInTouchRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<GetInTouch> AddGetInTouchAsync(GetInTouch getInTouch)
        {
            getInTouch.DateAdded = DateTime.UtcNow;
            getInTouch.DateUpdated = DateTime.UtcNow;

            if (getInTouch.CompanyId == 0)
            {
                getInTouch.CompanyId = null;
            }
            if (getInTouch.ServiceId == 0)
            {
                getInTouch.ServiceId = null;
            }
            var result = await _appDbContext.GetInTouches.AddAsync(getInTouch);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<GetInTouch?> DeleteGetInTouchAsync(int id)
        {
            var result = await _appDbContext.GetInTouches.FirstOrDefaultAsync(g => g.Id == id);
            if (result != null)
            {
                _appDbContext.GetInTouches.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<GetInTouch?> GetGetInTouchAsync(int id)
        {
            return await _appDbContext.GetInTouches
                .Include(g=> g.Service)
               .Include(g => g.Company)
               .FirstOrDefaultAsync(g => g.Id == id);

            //return await _appDbContext.GetInTouches.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<GetInTouch?> GetGetInTouchWithCompanyAsync(int id)
        {
            return await _appDbContext.GetInTouches
                .Include(g => g.Company)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public PagedResult<GetInTouch> GetGetInTouchRequests(string? email, bool? status, bool? isCompleted, int? service, int page)
        {
            int pageSize = 10;

            var query = _appDbContext.GetInTouches.Include(g => g.Company).AsQueryable();

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(g => g.Email.Contains(email, StringComparison.CurrentCultureIgnoreCase));
            }

            if (status.HasValue)
            {
                query = query.Where(g => g.Status == status.Value);
            }

            if (isCompleted.HasValue)
            {
                query = query.Where(g => g.IsCompleted == isCompleted.Value);
            }

            if (service.HasValue)
            {
                query = query.Where(g => g.ServiceId == service.Value);
            }


            return query.OrderByDescending(g => g.DateAdded)
                       .GetPaged(page, pageSize);
        }

        public async Task<GetInTouch?> UpdateGetInTouchAsync(GetInTouch getInTouch)
        {
            var result = await _appDbContext.GetInTouches.FirstOrDefaultAsync(g => g.Id == getInTouch.Id);
            if (result != null)
            {
                getInTouch.DateUpdated = DateTime.UtcNow;
                _appDbContext.Entry(result).CurrentValues.SetValues(getInTouch);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<GetInTouch?> UpdateStatusAsync(int id, bool status, bool isCompleted)
        {
            var result = await _appDbContext.GetInTouches.FirstOrDefaultAsync(g => g.Id == id);
            if (result != null)
            {
                result.Status = status;
                result.IsCompleted = isCompleted;
                result.DateUpdated = DateTime.UtcNow;
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<bool> GetInTouchExistsAsync(int id)
        {
            return await _appDbContext.GetInTouches.AnyAsync(g => g.Id == id);
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            var query = _appDbContext.GetInTouches.Where(g => g.Email == email);

            if (excludeId.HasValue)
            {
                query = query.Where(g => g.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<List<GetInTouch>> GetPendingRequestsAsync()
        {
            return await _appDbContext.GetInTouches
                .Include(g => g.Company)
                .Where(g => !g.IsCompleted)
                .OrderByDescending(g => g.DateAdded)
                .ToListAsync();
        }

        public async Task<List<GetInTouch>> GetCompletedRequestsAsync()
        {
            return await _appDbContext.GetInTouches
                .Include(g => g.Company)
                .Where(g => g.IsCompleted)
                .OrderByDescending(g => g.DateUpdated)
                .ToListAsync();
        }

        public async Task<List<GetInTouch>> GetRequestsByServiceAsync(int serviceId)
        {
            return await _appDbContext.GetInTouches
                .Include(g => g.Company)
                .Where(g => g.ServiceId == serviceId)
                .OrderByDescending(g => g.DateAdded)
                .ToListAsync();
        }

        public async Task<int> GetRequestCountByStatusAsync(bool status)
        {
            return await _appDbContext.GetInTouches
                .Where(g => g.Status == status)
                .CountAsync();
        }

        public PagedResult<GetInTouch> GetInTouchQuery(string? name, int page)
        {
            int pageSize = 10;

            var query = _appDbContext.GetInTouches.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(i => i.FullName != null && i.FullName.Contains(name, StringComparison.CurrentCultureIgnoreCase));
            }

            return query.OrderBy(i => i.FullName)
                       .GetPaged(page, pageSize);
        }

        public async Task<List<GetInTouch>> GetAllRequestsAsync()
        {
            return await _appDbContext.GetInTouches
                .OrderBy(t => t.Id)
                .ToListAsync();
        }
    }
}
