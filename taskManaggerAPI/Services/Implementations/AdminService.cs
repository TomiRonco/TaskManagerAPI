using Microsoft.EntityFrameworkCore;
using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.DBContext;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly taskContext _taskContext;

        public AdminService(taskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public List<User> GetAdmins()
        {
            return _taskContext.Users.Where(p => p.UserType == "Admin").ToList();
        }

       

        public Admin GetAdminById(int id)
        {
            return _taskContext.Admins.FirstOrDefault(p => p.Id == id);
        }

        public Admin UpdateAdmin(Admin admin)
        {
            _taskContext.Update(admin);
            _taskContext.SaveChanges();
            return admin;
        }
    }
}
