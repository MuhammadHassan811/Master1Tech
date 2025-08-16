using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Master1Tech.Server.Models
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public ServiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Service> AddServiceAsync(Service service)
        {
            var result = await _appDbContext.Services.AddAsync(service);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Service?> DeleteServiceAsync(int serviceId)
        {
            var result = await _appDbContext.Services.FirstOrDefaultAsync(s => s.ServiceID == serviceId);
            if (result != null)
            {
                // Check if service is being used by any companies
                var hasCompanies = await _appDbContext.CompanyServices
                    .AnyAsync(cs => cs.ServiceID == serviceId);

                if (hasCompanies)
                {
                    throw new InvalidOperationException("Cannot delete service that is associated with companies. Please remove all company associations first.");
                }

                _appDbContext.Services.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Service?> GetServiceAsync(int serviceId)
        {
            return await _appDbContext.Services.FirstOrDefaultAsync(s => s.ServiceID == serviceId);
        }

        public async Task<Service?> GetServiceWithCompaniesAsync(int serviceId)
        {
            return await _appDbContext.Services
                .Include(s => s.CompanyServices)
                .FirstOrDefaultAsync(s => s.ServiceID == serviceId);
        }

        public PagedResult<Service> GetServices(string? name, int page)
        {
            int pageSize = 10;

            var query = _appDbContext.Services.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(s => s.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
            }

            return query.OrderBy(s => s.Name)
                       .GetPaged(page, pageSize);
        }

        public async Task<Service?> UpdateServiceAsync(Service service)
        {
            var result = await _appDbContext.Services.FirstOrDefaultAsync(s => s.ServiceID == service.ServiceID);
            if (result != null)
            {
                _appDbContext.Entry(result).CurrentValues.SetValues(service);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<bool> ServiceExistsAsync(int serviceId)
        {
            return await _appDbContext.Services.AnyAsync(s => s.ServiceID == serviceId);
        }

        public async Task<bool> ServiceNameExistsAsync(string name, int? excludeId = null)
        {
            var query = _appDbContext.Services.Where(s => s.Name == name);

            if (excludeId.HasValue)
            {
                query = query.Where(s => s.ServiceID != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _appDbContext.Services
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<int> GetCompanyCountForServiceAsync(int serviceId)
        {
            return await _appDbContext.CompanyServices
                .Where(cs => cs.ServiceID == serviceId)
                .CountAsync();
        }
    }
}
