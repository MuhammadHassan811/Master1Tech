using Master1Tech.Server.Models;
using Master1Tech.Shared.DTOs.Service;
using Master1Tech.Shared.DTOs;
using Master1Tech.Server.Services.Mapping.ServiceMapping;

namespace Master1Tech.Server.Services.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceMappingService _mappingService;

        public ServiceService(IServiceRepository serviceRepository, IServiceMappingService mappingService)
        {
            _serviceRepository = serviceRepository;
            _mappingService = mappingService;
        }

        public PagedResultDto<ServiceDto> GetServices(string? name, int page)
        {
            var result = _serviceRepository.GetServices(name, page);
            return _mappingService.MapToPagedResultDto(result);
        }

        public async Task<ServiceDto?> GetServiceAsync(int serviceId)
        {
            var service = await _serviceRepository.GetServiceAsync(serviceId);
            if (service == null) return null;

            var companyCount = await _serviceRepository.GetCompanyCountForServiceAsync(serviceId);
            return _mappingService.MapToServiceDto(service, companyCount);
        }

        public async Task<ServiceDto?> GetServiceWithCompaniesAsync(int serviceId)
        {
            var service = await _serviceRepository.GetServiceWithCompaniesAsync(serviceId);
            if (service == null) return null;

            var companyCount = service.CompanyServices?.Count ?? 0;
            return _mappingService.MapToServiceDto(service, companyCount);
        }

        public async Task<ServiceDto> AddServiceAsync(ServiceCreateDto serviceCreateDto)
        {
            // Check if service name already exists
            if (await _serviceRepository.ServiceNameExistsAsync(serviceCreateDto.Name))
            {
                throw new InvalidOperationException($"Service with name '{serviceCreateDto.Name}' already exists.");
            }

            var service = _mappingService.MapToServiceEntity(serviceCreateDto);
            var addedService = await _serviceRepository.AddServiceAsync(service);
            return _mappingService.MapToServiceDto(addedService);
        }

        public async Task<ServiceDto?> UpdateServiceAsync(ServiceUpdateDto serviceUpdateDto)
        {
            // Check if service exists
            if (!await _serviceRepository.ServiceExistsAsync(serviceUpdateDto.ServiceID))
            {
                return null;
            }

            // Check if service name already exists for another service
            if (await _serviceRepository.ServiceNameExistsAsync(serviceUpdateDto.Name, serviceUpdateDto.ServiceID))
            {
                throw new InvalidOperationException($"Service with name '{serviceUpdateDto.Name}' already exists.");
            }

            var service = _mappingService.MapToServiceEntity(serviceUpdateDto);
            var updatedService = await _serviceRepository.UpdateServiceAsync(service);

            if (updatedService != null)
            {
                var companyCount = await _serviceRepository.GetCompanyCountForServiceAsync(updatedService.ServiceID);
                return _mappingService.MapToServiceDto(updatedService, companyCount);
            }

            return null;
        }

        public async Task<bool> DeleteServiceAsync(int serviceId)
        {
            try
            {
                var result = await _serviceRepository.DeleteServiceAsync(serviceId);
                return result != null;
            }
            catch (InvalidOperationException)
            {
                // Re-throw the exception so the controller can handle it
                throw;
            }
        }

        public async Task<bool> ServiceExistsAsync(int serviceId)
        {
            return await _serviceRepository.ServiceExistsAsync(serviceId);
        }

        public async Task<bool> ServiceNameExistsAsync(string name, int? excludeId = null)
        {
            return await _serviceRepository.ServiceNameExistsAsync(name, excludeId);
        }

        public async Task<List<ServiceSummaryDto>> GetAllServicesAsync()
        {
            var services = await _serviceRepository.GetAllServicesAsync();
            return services.Select(_mappingService.MapToServiceSummaryDto).ToList();
        }
    }
}
