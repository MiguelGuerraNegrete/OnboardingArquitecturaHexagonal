using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTransaction.Domain.Interfaces;

namespace AppTransaction.Domain.Interfaces.Repository
{
    public interface IReositoryDetail<Entity, MovimientoId> : IPost<Entity>, ITransaction
    {

    }
}
