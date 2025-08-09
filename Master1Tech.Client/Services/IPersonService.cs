using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Client.Services
{
    public interface IPersonService
    {
        Task<PagedResult<Person>> GetPeople(string? name, int page);
        Task<Person> GetPerson(int id);

        Task DeletePerson(int id);

        Task AddPerson(Person person);

        Task UpdatePerson(Person person);
    }
}