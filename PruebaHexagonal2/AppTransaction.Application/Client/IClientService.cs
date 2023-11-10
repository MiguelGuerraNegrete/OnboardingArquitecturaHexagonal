using AppTransaction.Domain;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IClientService
    {
        //Task ExecuteAsync();
        Task<IEnumerable<Client>> GetAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task Save(Client client);
    }
}
