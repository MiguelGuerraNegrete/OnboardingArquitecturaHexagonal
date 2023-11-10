using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Aplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repositoryOrder;

        public OrderService(IOrderRepository repositoryOrder)
        {
            _repositoryOrder = repositoryOrder;
        }

        public async Task ExecuteAsync()
        {

            var NewOrderId = Guid.NewGuid();

            var order = new Order
            {
                OrderId = NewOrderId,
                Units = 10,
                ProductValue = 10,
                Total = 100
            };
            await _repositoryOrder.Save(order);
        }
    }
}
