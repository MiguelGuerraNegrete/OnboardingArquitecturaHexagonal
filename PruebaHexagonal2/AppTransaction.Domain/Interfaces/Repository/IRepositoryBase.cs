namespace AppTransaction.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity,TEntityId> : IPost<TEntity>, IUpdate<TEntity>,IDelete<TEntityId>,IGet<TEntity, TEntityId>, ITransaction
    {
    }
}
