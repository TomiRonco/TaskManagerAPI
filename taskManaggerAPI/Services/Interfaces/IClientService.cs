using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IClientService
    {
        Client GetClientById(int clientId);
        IEnumerable<Client> GetAllClients();
    }
}
