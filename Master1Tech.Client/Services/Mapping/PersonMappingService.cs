using Master1Tech.Shared.Data;
using Master1Tech.Shared.DTOs;
using Master1Tech.Shared.DTOs.Person;
using Master1Tech.Shared.Models;

namespace Master1Tech.Client.Services.Mapping
{
    public class PersonMappingService : IPersonMappingService
    {
        public PersonDto MapToPersonDto(Person person)
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

        public Person MapToPersonEntity(PersonCreateDto personCreateDto)
        {
            return new Person
            {
                FirstName = personCreateDto.FirstName,
                LastName = personCreateDto.LastName,
                PhoneNumber = personCreateDto.PhoneNumber,
                Addresses = personCreateDto.Addresses?.Select(MapToAddressEntity).ToList() ?? new List<Address>()
            };
        }

        public Person MapToPersonEntity(PersonUpdateDto personUpdateDto)
        {
            return new Person
            {
                PersonId = personUpdateDto.PersonId,
                FirstName = personUpdateDto.FirstName,
                LastName = personUpdateDto.LastName,
                PhoneNumber = personUpdateDto.PhoneNumber,
                Addresses = personUpdateDto.Addresses?.Select(MapToAddressEntity).ToList() ?? new List<Address>()
            };
        }

        public AddressDto MapToAddressDto(Address address)
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

        public Address MapToAddressEntity(AddressDto addressDto)
        {
            return new Address
            {
                AddressId = addressDto.AddressId,
                Street = addressDto.Street,
                City = addressDto.City,
                State = addressDto.State,
                ZipCode = addressDto.ZipCode
            };
        }

        public Address MapToAddressEntity(AddressCreateDto addressCreateDto)
        {
            return new Address
            {
                Street = addressCreateDto.Street,
                City = addressCreateDto.City,
                State = addressCreateDto.State,
                ZipCode = addressCreateDto.ZipCode
            };
        }

        public PagedResultDto<PersonDto> MapToPagedResultDto(PagedResult<Person> pagedResult)
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
