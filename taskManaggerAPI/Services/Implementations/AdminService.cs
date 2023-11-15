using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.Entities;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin GetAdminById(int adminId)
        {
            return _adminRepository.GetAdminById(adminId);
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _adminRepository.GetAllAdmins();
        }
    }
}
