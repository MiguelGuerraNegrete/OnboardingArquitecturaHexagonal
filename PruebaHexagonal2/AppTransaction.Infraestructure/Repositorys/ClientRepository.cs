using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Infraestruture.Datos.Contexts.Repositorys
{
    public class ClientRepository : IRepositoryBase<Client, int>
    {
        private readonly TransactionContext _context;

        public ClientRepository(TransactionContext dbcontext)
        {
            _context = dbcontext;
        }

        List<Client> IGet<Client, int>.Get()
        {
            return _context.Clients.ToList();
        }

        Client IGet<Client, int>.GetById(int entityId)
        {
            var selecClient = _context.Clients.Where(c => c.ClientId == entityId).FirstOrDefault();
            return selecClient;
        }

        Client IPost<Client>.Post(Client entity)
        {
            _context.Clients.Add(entity);
            return entity;
        }

        void IUpdate<Client>.Update(Client entity)
        {
            var selecClient = _context.Clients.Where(c => c.ClientId == entity.ClientId).FirstOrDefault();
            if (selecClient != null)
            {
                selecClient.Identification = entity.Identification;
                selecClient.Name = entity.Name;
                selecClient.AvailableBalance = entity.AvailableBalance;

                _context.Entry(selecClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        void IDelete<int>.Delete(int entityId)
        {
            var selecClient = _context.Clients.Where(c => c.ClientId == entityId).FirstOrDefault();
            if (selecClient != null)
            {
                _context.Clients.Remove(selecClient);
            }
        }

        void ITransaction.SaveAllChanges()
        {
            _context.SaveChanges();
        }
    }
}
