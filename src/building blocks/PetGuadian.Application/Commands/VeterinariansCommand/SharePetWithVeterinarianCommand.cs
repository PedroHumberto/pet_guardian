using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.VeterinariansCommand
{
    public class SharePetWithVeterinarianCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public SharePetWithVeterinarianCommand(Guid petId)
        {
            PetId = petId;
        }

        public SharePetWithVeterinarianCommand()
        {
        }

        public Guid PetId { get; set; }
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}