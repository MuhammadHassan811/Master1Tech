using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs.Person;
using Master1Tech.Shared.DTOs;

namespace Master1Tech.Server.Services.Mapping.PersonMapping
{
    public class PersonMappingService : IPersonMappingService
    {
        public PersonDto MapToPersonDto(Master1Tech.Shared.Models.Person person)
        {
            return new PersonDto
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Addresses = person.Addresses?.Select(MapToAddressDto).ToList() ?? new List<AddressDto>()
            };
        }

        public Master1Tech.Shared.Models.Person MapToPersonEntity(PersonCreateDto personCreateDto)
        {
            return new Master1Tech.Shared.Models.Person
            {
                FirstName = personCreateDto.FirstName,
                LastName = personCreateDto.LastName,
                PhoneNumber = personCreateDto.PhoneNumber,
                Addresses = personCreateDto.Addresses?.Select(MapToAddressEntity).ToList() ?? new List<Master1Tech.Shared.Models.Address>()
            };
        }

        public Master1Tech.Shared.Models.Person MapToPersonEntity(PersonUpdateDto personUpdateDto)
        {
            return new Master1Tech.Shared.Models.Person
            {
                PersonId = personUpdateDto.PersonId,
                FirstName = personUpdateDto.FirstName,
                LastName = personUpdateDto.LastName,
                PhoneNumber = personUpdateDto.PhoneNumber,
                Addresses = personUpdateDto.Addresses?.Select(MapToAddressEntity).ToList() ?? new List<Master1Tech.Shared.Models.Address>()
            };
        }

        public AddressDto MapToAddressDto(Master1Tech.Shared.Models.Address address)
        {
            return new AddressDto
            {
                AddressId = address.AddressId,
                Street = address.Street,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode
            };
        }

        public Master1Tech.Shared.Models.Address MapToAddressEntity(AddressDto addressDto)
        {
            return new Master1Tech.Shared.Models.Address
            {
                AddressId = addressDto.AddressId,
                Street = addressDto.Street,
                City = addressDto.City,
                State = addressDto.State,
                ZipCode = addressDto.ZipCode
            };
        }

        public Master1Tech.Shared.Models.Address MapToAddressEntity(AddressCreateDto addressCreateDto)
        {
            return new Master1Tech.Shared.Models.Address
            {
                Street = addressCreateDto.Street,
                City = addressCreateDto.City,
                State = addressCreateDto.State,
                ZipCode = addressCreateDto.ZipCode
            };
        }

        public PagedResultDto<PersonDto> MapToPagedResultDto(PagedResult<Master1Tech.Shared.Models.Person> pagedResult)
        {
            return new PagedResultDto<PersonDto>
            {
                Results = pagedResult.Results.Select(MapToPersonDto).ToList(),
                CurrentPage = pagedResult.CurrentPage,
                PageCount = pagedResult.PageCount,
                PageSize = pagedResult.PageSize,
                RowCount = pagedResult.RowCount,
                FirstRowOnPage = pagedResult.FirstRowOnPage,
                LastRowOnPage = pagedResult.LastRowOnPage
            };
        }
    }
}
