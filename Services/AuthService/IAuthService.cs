using API.Dtos;
using API.Models;

namespace API.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> UserExists(string Login);
        Task<ServiceResponse<string>> Login(string Login, string password);
        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
       
        Task<User?> GetUserByLogin(string Login);
    }
}
