using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Interfaces
{
    public interface IClientRepository
    {
        Client GetClientById(int clientId);
        IEnumerable<Client> GetAllClients();
        //void CreateClient(Client client);

    }
}
