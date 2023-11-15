using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Interfaces
{
    public interface IAdminRepository
    {
        Admin GetAdminById(int AdminId);
        IEnumerable<Admin> GetAllAdmins();
        //void CreateAdmin(Admin admin);
    }
}
