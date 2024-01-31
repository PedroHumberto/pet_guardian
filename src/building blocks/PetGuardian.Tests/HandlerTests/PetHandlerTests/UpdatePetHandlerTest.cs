using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Handlers;
using PetGuardian.Tests.Repositories;

namespace PetGuardian.Tests.HandlerTests.PetHandlerTests
{
    [TestClass]
    public class UpdatePetHandlerTest
    {
        private readonly UpdatePetCommand _invalidCommand = new UpdatePetCommand(Guid.NewGuid(), Guid.NewGuid(), "Jorge", 'G', DateTime.Now, 15);
        private readonly UpdatePetCommand _validCommand = new UpdatePetCommand(Guid.NewGuid(), Guid.NewGuid(), "Jorge", 'M', DateTime.Now, 15);
        private readonly PetHandler _handler = new PetHandler(new FakePetService());
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
            Assert.AreEqual(_result.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_command_is_valid_need_to_execute_Service()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public async Task When_command_is_valid_the_result_needs_to_return_Created()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.StatusCode, HttpStatusCode.Created);
        }
    }
}