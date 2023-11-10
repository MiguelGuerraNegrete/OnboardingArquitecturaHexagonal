using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces;
using AppTransaction.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AppTransaction.Infraestruture.Datos.Contexts.Repositorys
{
    public class ClientRepository : IClientRepository
    {
        private readonly TransactionContext _context;

        public ClientRepository(TransactionContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<IEnumerable<Client>> GetAsync() => await _context.Clients.ToListAsync();

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task Save(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }
    }
}
