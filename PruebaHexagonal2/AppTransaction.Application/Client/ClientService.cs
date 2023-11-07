using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Aplication.Services
{
    public class ClientService : IClientService<Client, int>
    {
        private readonly IRepositoryBase<Client, int> _repositoryBaseClient; 

        public ClientService(IRepositoryBase<Client, int> repositoryBaseClient)
        {
            _repositoryBaseClient = repositoryBaseClient;
        }

        public List<Client> Get()
        {
           return _repositoryBaseClient.Get();
        }

        public Client GetById(int entityId)
        {
            return _repositoryBaseClient.GetById(entityId);
        }

        public Client Post(Client entity)
        {
            if (entity == null)
            {         
                throw new ArgumentNullException("Client is required");
            }
            var clienResult = _repositoryBaseClient.Post(entity);
            _repositoryBaseClient.SaveAllChanges();
            return clienResult;
        }

        public void Update(Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Client is required");
            }
            _repositoryBaseClient.Update(entity);
            _repositoryBaseClient.SaveAllChanges();
        }

        public void Delete(int entityId)
        {
            _repositoryBaseClient.Delete(entityId);
            _repositoryBaseClient.SaveAllChanges();
        }
    }
}
