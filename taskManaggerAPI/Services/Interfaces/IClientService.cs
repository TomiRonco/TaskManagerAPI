using taskManaggerAPI.Data.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IClientService
    {
        List<User> GetClients();  
        Client GetClientById(int id);
        Client UpdateClient(Client client);
    }
}
