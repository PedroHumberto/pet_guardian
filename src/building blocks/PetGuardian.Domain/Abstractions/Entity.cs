using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Abstractions
{
    public abstract class Entity : IEquatable<Entity>
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public Entity(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity? other)
        {
            return Id == other?.Id;
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}