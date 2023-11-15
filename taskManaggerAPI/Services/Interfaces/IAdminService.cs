using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IAdminService
    {
        Admin GetAdminById(int adminId);
        IEnumerable<Admin> GetAllAdmins();
    }
}
