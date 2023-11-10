using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces;
using AppTransaction.Domain.Interfaces.Repository;

namespace AppTransaction.Infraestruture.Datos.Contexts.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly TransactionContext _context;

        public ProductRepository(TransactionContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Save(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
