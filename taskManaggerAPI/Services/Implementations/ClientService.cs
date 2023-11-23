using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.DBContext;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly taskContext _taskContext;

        public ClientService(taskContext taskContext)
        {
                _taskContext = taskContext;
        }

        public List<User> GetClients()
        {
            return _taskContext.Users.Where(p => p.UserType == "Client").ToList();
        }

        public Client GetClientById(int id)
        {
            return _taskContext.Clients.FirstOrDefault(p => p.Id == id);
        }

        public Client UpdateClient(Client client)
        {
            _taskContext.Update(client);
            _taskContext.SaveChanges();
            return client;
        }
    }
}
