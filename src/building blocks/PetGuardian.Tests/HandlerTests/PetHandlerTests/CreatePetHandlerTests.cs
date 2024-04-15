using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Handlers.Pets;
using PetGuardian.Core.PetGuardianCore.Enums;
using PetGuardian.Tests.Repositories;

namespace PetGuardian.Tests.HandlerTests.PetHandlerTests
{
    [TestClass]
    public class CreatePetHandlerTests
    {
        private readonly CreatePetCommand _invalidCommand = new CreatePetCommand("L", 'A', AnimalSpecies.Dog, DateTime.Now, 15, Guid.NewGuid());

        private readonly CreatePetCommand _validCommand = new CreatePetCommand("Luci", 'F', AnimalSpecies.Dog, DateTime.Now, 15, Guid.NewGuid());
        private readonly CreatePetHandler _handler = new CreatePetHandler(new FakePetRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        private readonly CancellationToken _cancellationToken = new CancellationToken();

        [TestMethod]
        public async Task When_command_is_invalid_need_interrupt_execution()
        {
            _result = (GenericCommandResult)await _handler.Handle(_invalidCommand, _cancellationToken);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public async Task When_command_is_invalid_the_result_needs_to_return_StatusCode_BadRequest()
        {
            _result = (GenericCommandResult)await _handler.Handle(_invalidCommand, _cancellationToken);
            Assert.AreEqual(_result.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_command_is_valid_need_to_execute_Service()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand, _cancellationToken);
            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public async Task When_command_is_valid_the_result_needs_to_return_200Ok()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand, _cancellationToken);
            Assert.AreEqual(_result.StatusCode, HttpStatusCode.Created);
        }
    }
}