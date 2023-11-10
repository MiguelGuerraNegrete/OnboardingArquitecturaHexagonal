using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Infraestruture.Datos.Contexts.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TransactionContext _context;

        public OrderRepository(TransactionContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<Order> GetAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task Save(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
