using taskManaggerAPI.Data.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IAdminService
    {
        List<User> GetAdmins();
        Admin GetAdminById(int id);
        Admin UpdateAdmin(Admin admin);

    }
}
