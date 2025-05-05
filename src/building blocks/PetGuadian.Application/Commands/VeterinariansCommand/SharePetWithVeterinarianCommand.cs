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

        public SharePetWithVeterinarianCommand()
        {
        }

        public SharePetWithVeterinarianCommand(Guid vetId, Guid petId, Guid userId)
        {
            VetId = vetId;
            PetId = petId;
            UserId = userId;
        }

        public Guid UserId { get; set; }
        public Guid VetId { get; set; }
        public Guid PetId { get; set; }
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}