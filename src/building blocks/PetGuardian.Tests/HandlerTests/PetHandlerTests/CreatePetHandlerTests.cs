using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Handlers;
using PetGuardian.Core.PetGuardianCore.Enums;
using PetGuardian.Tests.Repositories;

namespace PetGuardian.Tests.HandlerTests.PetHandlerTests
{
    [TestClass]
    public class CreatePetHandlerTests
    {
        private readonly CreatePetCommand _invalidCommand = new CreatePetCommand("L", 'A', AnimalSpecies.Dog, DateTime.Now, 15, Guid.NewGuid());

        private readonly CreatePetCommand _validCommand = new CreatePetCommand("Luci", 'F', AnimalSpecies.Dog, DateTime.Now, 15, Guid.NewGuid());
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