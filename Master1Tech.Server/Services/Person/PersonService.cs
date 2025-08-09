using Master1Tech.Client.Services.Mapping;
using Master1Tech.Server.Models;
using Master1Tech.Shared.DTOs.Person;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonMappingService _mappingService;

        public PersonService(IPersonRepository personRepository, IPersonMappingService mappingService)
        {
            _personRepository = personRepository;
            _mappingService = mappingService;
        }

        public PagedResultDto<PersonDto> GetPeople(string? name, int page)
        {
            var result = _personRepository.GetPeople(name, page);
            return _mappingService.MapToPagedResultDto(result);
        }

        public async Task<PersonDto?> GetPersonAsync(int personId)
        {
            try
            {
                var person = await _personRepository.GetPerson(personId);
                return person != null ? _mappingService.MapToPersonDto(person) : null;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public async Task<PersonDto> AddPersonAsync(PersonCreateDto personCreateDto)
        {
            var person = _mappingService.MapToPersonEntity(personCreateDto);
            var addedPerson = await _personRepository.AddPerson(person);
            return _mappingService.MapToPersonDto(addedPerson);
        }

        public async Task<PersonDto?> UpdatePersonAsync(PersonUpdateDto personUpdateDto)
        {
            try
            {
                var person = _mappingService.MapToPersonEntity(personUpdateDto);
                var updatedPerson = await _personRepository.UpdatePerson(person);
                return updatedPerson != null ? _mappingService.MapToPersonDto(updatedPerson) : null;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public async Task<bool> DeletePersonAsync(int personId)
        {
            try
            {
                var result = await _personRepository.DeletePerson(personId);
                return result != null;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
    }

}
