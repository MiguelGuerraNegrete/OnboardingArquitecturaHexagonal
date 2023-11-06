using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IClientService<TEntity, TEntityId> : IPost<TEntity>, IUpdate<TEntity>, IDelete<TEntityId>, IGet<TEntity, TEntityId>
    {
        Client Post(Client entity);
    }
}
