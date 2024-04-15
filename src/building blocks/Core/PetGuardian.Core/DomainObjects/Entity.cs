using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardian.Core.PetGuardianCore.DomainObjects
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity? other)
        {
            return Id == other?.Id;
        }
    }
}