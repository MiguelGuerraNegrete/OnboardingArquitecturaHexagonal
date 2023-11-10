using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IProductService
    {
        Task ExecuteAsync();
    }
}
