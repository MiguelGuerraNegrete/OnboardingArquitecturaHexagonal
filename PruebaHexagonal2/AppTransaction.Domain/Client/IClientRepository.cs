namespace AppTransaction.Domain.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task Save(Client client);
    }
}
