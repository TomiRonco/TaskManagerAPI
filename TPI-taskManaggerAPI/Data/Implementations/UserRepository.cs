using TPI_taskManaggerAPI.Data.Interfaces;
using TPI_taskManaggerAPI.DBContext;
using TPI_taskManaggerAPI.Entities;

namespace TPI_taskManaggerAPI.Data.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly taskManaggerContext _context;

        public UserRepository(taskManaggerContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
