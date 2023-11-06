using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Infraestruture.Datos.Contexts.Repositorys
{
    public class ProductRepository : IRepositoryBase<Product, int>
    {
        private readonly TransactionContext _context;

        public ProductRepository(TransactionContext dbcontext)
        {
            _context = dbcontext;
        }

        List<Product> IGet<Product, int>.Get()
        {
            return _context.Products.ToList();
        }

        Product IGet<Product, int>.GetById(int entityId)
        {
            var selecProduct = _context.Products.Where(c => c.ProductId == entityId).FirstOrDefault();
            return selecProduct;
        }

        Product IPost<Product>.Post(Product entity)
        {
            entity.ProductId = int.MaxValue;
            _context.Products.Add(entity);
            return entity;
        }

        void IUpdate<Product>.Update(Product entity)
        {
            var selecProduct = _context.Products.Where(c => c.ProductId == entity.ProductId).FirstOrDefault();
            if (selecProduct != null)
            {
                selecProduct.ProductName = entity.ProductName;
                selecProduct.ProductValue = entity.ProductValue;
                selecProduct.ProductCode = entity.ProductCode;

                _context.Entry(selecProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        void IDelete<int>.Delete(int entityId)
        {
            var selecProduct = _context.Products.Where(c => c.ProductId == entityId).FirstOrDefault();
            if (selecProduct != null)
            {
                _context.Products.Remove(selecProduct);
            }
        }

        void ITransaction.SaveAllChanges()
        {
            _context.SaveChanges();
        }
    }
}
