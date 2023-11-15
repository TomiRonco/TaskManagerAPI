using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        //void CreateUser(User user);
    }
}
