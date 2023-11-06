namespace AppTransaction.Domain.Interfaces
{
    public interface IGet<TEntity, TEntityId>
    {
        List<TEntity> Get();

        TEntity GetById(TEntityId entityId);
    }
}
