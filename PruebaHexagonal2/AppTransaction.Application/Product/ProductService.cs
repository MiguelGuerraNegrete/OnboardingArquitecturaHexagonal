using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Aplication.Services
{
    public class ProductService : IProductService<Product, int>
    {
        private readonly IRepositoryBase<Product, int> _repositoryProduct;

        public ProductService(IRepositoryBase<Product, int> repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public List<Product> Get()
        {
            return _repositoryProduct.Get();
        }

        public Product GetById(int entityId)
        {
            return _repositoryProduct.GetById(entityId);
        }

        public Product Post(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Product is required");
            }
            var newProduct = _repositoryProduct.Post(entity);
            _repositoryProduct.SaveAllChanges();
            return newProduct;
        }

        public void Update(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Product is required");
            }
            _repositoryProduct.Update(entity);
            _repositoryProduct.SaveAllChanges();
        }

        public void Delete(int entityId)
        {
            _repositoryProduct.Delete(entityId);
            _repositoryProduct.SaveAllChanges();
        }
    }
}
