using Master1Tech.Server.Authorization;
using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Models
{
    public interface IUserRepository
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        PagedResult<User> GetUsers(string? name, int page);
        Task<User?> GetUser(int Id);
        Task<User> AddUser(User user);
        Task<User?> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
    }
}