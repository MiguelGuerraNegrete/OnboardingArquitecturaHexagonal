namespace AppTransaction.Domain.Interfaces.Repository
{
    public interface IRepositoryOrder<TEntity, TEntityID> : IPost<TEntity>, IGet<TEntity,TEntityID>, ITransaction
    {
    void Delete(TEntityID entityId);
    }
}
