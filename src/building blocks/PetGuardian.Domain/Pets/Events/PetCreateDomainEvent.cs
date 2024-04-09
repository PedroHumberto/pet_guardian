using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Domain.Abstractions;

namespace PetGuardian.Domain.Pets.Events
{    public sealed record PetCreateDomainEvent(Guid UserId) : IDomainEvent;

}