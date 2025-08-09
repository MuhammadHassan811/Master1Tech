using Master1Tech.Shared.DTOs.Person;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Person
{
    public interface IPersonService
    {
        PagedResultDto<PersonDto> GetPeople(string? name, int page);
        Task<PersonDto?> GetPersonAsync(int personId);
        Task<PersonDto> AddPersonAsync(PersonCreateDto personCreateDto);
        Task<PersonDto?> UpdatePersonAsync(PersonUpdateDto personUpdateDto);
        Task<bool> DeletePersonAsync(int personId);
    }
}
