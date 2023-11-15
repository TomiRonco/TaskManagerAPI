using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
    }
}
