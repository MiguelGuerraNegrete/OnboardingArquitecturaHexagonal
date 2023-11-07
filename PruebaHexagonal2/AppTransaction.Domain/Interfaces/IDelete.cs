namespace AppTransaction.Domain.Interfaces
{
    public interface IDelete<TEntityId>
    {
        void Delete(TEntityId entityId);
    }
}
