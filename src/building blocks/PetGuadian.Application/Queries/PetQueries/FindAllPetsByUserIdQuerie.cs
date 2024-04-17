using MediatR;
using PetGuadian.Application.Abstractions;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Queries.PetQueries
{
    public class FindAllPetsByUserIdQuerie : IQuery<ICommandResult>
    {
        public Guid Id { get; set; }
    }
}