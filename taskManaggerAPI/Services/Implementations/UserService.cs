using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.Entities;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
