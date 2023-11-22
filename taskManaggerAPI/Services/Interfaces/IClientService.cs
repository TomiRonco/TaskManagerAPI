using taskManaggerAPI.Data.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IClientService
    {
        List<User> GetClientsTrue();
        List<User> GetClientsFalse();
        Client GetClientById(int id);
        Client UpdateClient(Client client);
    }
}
