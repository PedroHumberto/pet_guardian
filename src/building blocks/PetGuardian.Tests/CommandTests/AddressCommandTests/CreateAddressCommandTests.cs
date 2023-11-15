using PetGuadian.Application.Commands.AddressCommand;

namespace PetGuardian.Tests.CommandTests.AddressCommandTests
{
    [TestClass]
    public class CreateAddressCommandTests
    {
        private readonly CreateAddressCommand _invalidCommand = new CreateAddressCommand(" ", " ", "", "  ", "", "", "", Guid.NewGuid());
        private readonly CreateAddressCommand _validCommand = new CreateAddressCommand("Rua Tal", "123", "Casa 02", "Barroca", "Belo Horizonte", "MG", "301112223", Guid.NewGuid());
        [TestMethod]
        public void If_Command_Is_Invalid_Returns_False()
        {
            _invalidCommand.Execute();
            Assert.AreEqual(_invalidCommand.IsValid, false);
        }
        [TestMethod]
        public void If_Command_Is_Valid_Returns_True()
        {
            _validCommand.Execute();
            Assert.AreEqual(_validCommand.IsValid, true);
        }
    }
}