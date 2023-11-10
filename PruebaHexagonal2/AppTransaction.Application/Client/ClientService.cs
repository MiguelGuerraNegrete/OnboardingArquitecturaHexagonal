using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Aplication.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository; 

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        
        public async Task<IEnumerable<Client>> GetAsync()
        {
            return await _clientRepository.GetAsync();
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public  Task Save(Client client)
        {
            var clienResult = _clientRepository.Save(client);
            return clienResult;
        }
    }
}
