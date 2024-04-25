using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.VeterinariansCommand;

namespace PetGuadian.Application.Handlers.Users
{
    public class SharePetWithVeterinarianHandler : IRequestHandler<SharePetWithVeterinarianCommand, ICommandResult>
    {
        public Task<ICommandResult> Handle(SharePetWithVeterinarianCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}