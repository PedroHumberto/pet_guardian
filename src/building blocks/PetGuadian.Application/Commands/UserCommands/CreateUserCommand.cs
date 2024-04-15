
using Flunt.Notifications;
using Flunt.Validations;
using PetGuadian.Application.Commands.Contracts;
using PetGuardian.Core.PetGuardianCore.Enums;
using PetGuardian.Domain.Models;

namespace PetGuadian.Application.Commands.UserCommands
{
    public class CreateUserCommand : Notifiable<Notification>, ICommand
    {
        public CreateUserCommand()
        {
        }

        public CreateUserCommand(Guid userIdentity, string name, string email, Guid? addressId)
        {
            UserIdentity = userIdentity;
            Name = name;
            Email = email;
            AddressId = addressId;
        }

        public Guid UserIdentity { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? AddressId { get; set; }

        public void Execute()
        {
            AddNotifications(new Contract<CreateUserCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(Name, 4, "The user name needs to be more than 3 charcteres")
                .IsEmail(Email, Email)
            );
        }
    }
}