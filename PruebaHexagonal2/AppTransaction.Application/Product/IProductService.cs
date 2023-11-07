using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IProductService<TEntity, TEntityId> : IPost<TEntity>, IUpdate<TEntity>, IDelete<TEntityId>, IGet<TEntity, TEntityId>
    {
        Product Post(Product entity);
    }
}
