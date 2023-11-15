using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.DBContexts;
using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(taskManaggerContext context) : base(context) { }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        //public void CreateUser(User user)
        //{
        //    _context.Users.Add(user);
        //    SaveChanges();
        //}
    }
}
