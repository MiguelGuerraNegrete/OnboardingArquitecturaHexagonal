using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Aplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository repositoryProduct)
        {
            _ProductRepository = repositoryProduct;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _ProductRepository.GetAsync();
        }

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            return await _ProductRepository.GetByAsync(productId);
        }

        public Task SaveAsync(Product product)
        {
            var newProduct = _ProductRepository.SaveAsync(product);
            return newProduct;
        }
    }
}
