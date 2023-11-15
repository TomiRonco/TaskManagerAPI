using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.Entities;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client GetClientById(int clientId)
        {
            return _clientRepository.GetClientById(clientId);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

    }
}
