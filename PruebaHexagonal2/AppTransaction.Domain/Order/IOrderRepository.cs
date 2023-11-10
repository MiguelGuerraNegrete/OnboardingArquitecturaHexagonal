namespace AppTransaction.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(Guid id);
        Task Save(Order order);
    }
}
