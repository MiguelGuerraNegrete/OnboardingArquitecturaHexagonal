using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IServiceMovimiento<Entity, EntityId> : IPost<Entity>, IGet<Entity, EntityId>
    {
        void Cancel(EntityId entityId);
    }
}
