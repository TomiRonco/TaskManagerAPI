using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.Data.Models;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IUserService
    {
        public BaseResponse UserValidation(string username, string password);
        public User? GetUserByEmail(string username);
        int CreateUser (User user);
        void DeleteUser (int userId);
    }
}
