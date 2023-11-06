using AppTransaction.Domain.Interfaces;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IOrderService<TEntity, TEntityId> : IPost<TEntity>, IGet<TEntity, TEntityId>
    {
        void Cancel(TEntityId entityId);
    }
}
