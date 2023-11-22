using taskManaggerAPI.Data.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IAdminService
    {
        List<User> GetAdminsTrue();
        List<User> GetAdminsFalse();
        Admin GetAdminById(int id);
        Admin UpdateAdmin(Admin admin);

    }
}
