using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.DBContexts;
using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Implementations
{
    public class ClientRepository : Repository, IClientRepository
    {
        public ClientRepository(taskManaggerContext context) : base(context) { }

        public Client GetClientById(int clientId)
        {
            return _context.Clients.Find(clientId);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        //public void CreateClient(Client client)
        //{
        //    _context.Clients.Add(client);
        //    SaveChanges();
        //}
    }
}
