using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Queries.PetQueries
{
    public class FindAllPetsByUserIdCommand : IRequest<ICommandResult>
    {
        public Guid Id { get; set; }
    }
}