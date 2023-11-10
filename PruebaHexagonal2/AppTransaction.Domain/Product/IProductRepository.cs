namespace AppTransaction.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(Guid id);
        Task Save(Product product);
    }
}
