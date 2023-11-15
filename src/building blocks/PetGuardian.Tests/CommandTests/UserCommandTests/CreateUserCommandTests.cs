using PetGuadian.Application.Commands.UserCommands;
using PetGuardian.Core.PetGuardianCore.Enums;

namespace PetGuardian.Tests.CommandTests.UserCommandTests
{
    [TestClass]
    public class CreateUserCommandTests
    {

        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand(Guid.NewGuid(), "Ped", "teste@email.com", Guid.NewGuid());
        private readonly CreateUserCommand _validCommand = new CreateUserCommand(Guid.NewGuid(), "Pedro", "teste@email.com", Guid.NewGuid());

        [TestMethod]
        public void If_command_is_invalid_returns_false()
        {
            _invalidCommand.Execute();
            Assert.AreEqual(_invalidCommand.IsValid, false);
        }
        [TestMethod]
        public void If_command_is_valid_returns_true()
        {
            _validCommand.Execute();
            Assert.AreEqual(_validCommand.IsValid, true);
        }
        
        
    }
}