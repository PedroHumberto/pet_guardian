using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Abstractions;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Queries.PetQueries
{
    public class FindPetByIdQuerie : IQuery<ICommandResult>
    {
        public Guid UserId { get; set; }
        public Guid PetId { get; set; }
    }
}