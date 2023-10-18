using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot//apenas entidades podem ser relacionadas.
    {
        IUnitOfWork UnitOfWork { get; }

    }
}
