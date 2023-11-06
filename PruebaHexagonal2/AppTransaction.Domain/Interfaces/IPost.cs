namespace AppTransaction.Domain.Interfaces
{
    public interface IPost<TEntity>
    {
        TEntity Post(TEntity entity);
    }
    
}
