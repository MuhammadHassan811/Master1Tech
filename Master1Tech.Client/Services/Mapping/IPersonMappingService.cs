using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs;
using Master1Tech.Shared.DTOs.Person;
using Master1Tech.Shared.Models;

namespace Master1Tech.Client.Services.Mapping
{
    public interface IPersonMappingService
    {
        PersonDto MapToPersonDto(Person person);
        Person MapToPersonEntity(PersonCreateDto personCreateDto);
        Person MapToPersonEntity(PersonUpdateDto personUpdateDto);
        AddressDto MapToAddressDto(Address address);
        Address MapToAddressEntity(AddressDto addressDto);
        Address MapToAddressEntity(AddressCreateDto addressCreateDto);
        PagedResultDto<PersonDto> MapToPagedResultDto(PagedResult<Person> pagedResult);
    }
}
