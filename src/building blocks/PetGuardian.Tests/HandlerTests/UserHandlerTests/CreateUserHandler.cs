
using System.Net;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Commands.UserCommands;
using PetGuadian.Application.Handlers;
using PetGuardian.Tests.Services;

namespace PetGuardian.Tests.HandlerTests.UserHandlerTests
{
    [TestClass]
    public class CreateUserHandler
    {
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand(Guid.NewGuid(), "Ped", "teste@email.com", Guid.NewGuid());
        private readonly CreateUserCommand _validCommand = new CreateUserCommand(Guid.NewGuid(), "Pedro", "teste@email.com", Guid.NewGuid());
        
        private readonly UserHandler _handler = new UserHandler(new FakeUserService());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public async Task When_command_is_invalid_need_interrupt_execution()
        {
            _result = (GenericCommandResult)await _handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public async Task When_command_is_invalid_the_result_needs_to_return_StatusCode_NotFound()
        {
            _result = (GenericCommandResult)await _handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task When_command_is_valid_need_to_execute_Service()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public async Task When_command_is_valid_the_result_needs_to_return_200Ok()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.StatusCode, HttpStatusCode.OK);
        }

    }
}