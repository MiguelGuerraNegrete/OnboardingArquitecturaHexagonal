using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Infraestruture.Datos.Contexts.Repositorys
{
    public class OrderRepository : IRepositoryOrder<Order, long>
    {
        private readonly TransactionContext _context;

        public OrderRepository(TransactionContext dbcontext)
        {
            _context = dbcontext;
        }

        public List<Order> Get()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(long entityId)
        {
            var selecOrder = _context.Orders.Where(c => c.OrderId == entityId).FirstOrDefault();
            return selecOrder;
        }

        public Order Post(Order entity)
        {
            entity.OrderId = int.MaxValue;
            _context.Orders.Add(entity);
            return entity;
        }

        public void Delete(long entityId)
        {
            var orderSelec = _context.Orders.Where(c => c.OrderId == entityId).FirstOrDefault();
            
            if(orderSelec != null) 
            {
                throw new InvalidOperationException("Order not exist");
            }

            orderSelec.Canceled = true;
            _context.Entry(orderSelec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void SaveAllChanges()
        {
            _context.SaveChanges();
        }
    }
}
