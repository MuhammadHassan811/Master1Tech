using Master1Tech.Client.Shared;
using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Client.Services
{
    public interface IUserService
    {
        User User {get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task<PagedResult<User>> GetUsers(string name, string page);
        Task<User> GetUser(int id);
        Task DeleteUser(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
    }
}