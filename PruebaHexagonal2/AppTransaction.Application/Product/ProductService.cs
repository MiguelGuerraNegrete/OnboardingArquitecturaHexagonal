using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Aplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repositoryProduct;

        public ProductService(IProductRepository repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public async Task ExecuteAsync()
        {

            var NewProductId = Guid.NewGuid();

            var product = new Product
            {
                ProductId = NewProductId,
                ProductCode = 10,
                ProductName = "Chair",
                ProductValue = 100
            };
            await _repositoryProduct.Save(product);
        }
    }
}
