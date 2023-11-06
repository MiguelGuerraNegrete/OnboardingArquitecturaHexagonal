using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Aplication.Services
{
    public class OrderService : IOrderService<Order, long>
    {
        private readonly IRepositoryOrder<Order, long> _repositoryOrder;

        public OrderService(IRepositoryOrder<Order,long> repositoryOrder)
        {
            _repositoryOrder = repositoryOrder;
        }

        public void Cancel(long entityId)
        {
            _repositoryOrder.Delete( entityId );
            _repositoryOrder.SaveAllChanges();
        }

        public List<Order> Get()
        {
            return _repositoryOrder.Get();
        }

        public Order GetById(long entityId)
        {
            return _repositoryOrder.GetById(entityId);
        }   

        public Order Post(Order entity)
        {
            if (entity == null) throw new ArgumentNullException("Order is required");
            
            var newOrder = _repositoryOrder.Post(entity);
            _repositoryOrder.SaveAllChanges();
            return newOrder;
        }
    }
}
