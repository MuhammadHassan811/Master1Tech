using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.Person;
using Master1Tech.Shared.DTOs;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Services.Mapping.PersonMapping
{
    public interface IPersonMappingService
    {
        PersonDto MapToPersonDto(Master1Tech.Shared.Models.Person person);
        Master1Tech.Shared.Models.Person MapToPersonEntity(PersonCreateDto personCreateDto);
        Master1Tech.Shared.Models.Person MapToPersonEntity(PersonUpdateDto personUpdateDto);
        AddressDto MapToAddressDto(Address address);
        Address MapToAddressEntity(AddressDto addressDto);
        Address MapToAddressEntity(AddressCreateDto addressCreateDto);
        PagedResultDto<PersonDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.Person> pagedResult);
    }
}
