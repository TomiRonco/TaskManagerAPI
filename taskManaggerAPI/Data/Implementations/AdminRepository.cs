using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.DBContexts;
using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Implementations
{
    public class AdminRepository : Repository, IAdminRepository
    {
        public AdminRepository(taskManaggerContext context) : base(context) { }

        public Admin GetAdminById(int AdminId)
        {
            return _context.Admins.Find(AdminId);
        }
        public IEnumerable<Admin> GetAllAdmins()
        {
            return _context.Admins.ToList();
        }

        //public void CreateAdmin(Admin admin)
        //{
        //    _context.Admins.Add(admin);
        //    SaveChanges();
        //}

    }
}
