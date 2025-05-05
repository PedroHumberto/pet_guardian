using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetGuadian.Application.Commands.AddressCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Handlers.Adresses;
using PetGuardian.Tests.Services;

namespace PetGuardian.Tests.HandlerTests.AddressHandlerTests
{
    [TestClass]
    public class AddressHandlerTests
    {
        private readonly CreateAddressCommand _invalidCommand = new CreateAddressCommand(" ", " ", "", "  ", "", "", "");
        private readonly CreateAddressCommand _validCommand = new CreateAddressCommand("Rua Tal", "123", "Casa 02", "Barroca", "Belo Horizonte", "MG", "301112223");
        private readonly CreateAddressHandler _handler = new CreateAddressHandler(new FakeAddressRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        private readonly CancellationToken cancellationToken = new CancellationToken();

        [TestMethod]
        public async Task When_command_is_invalid_need_interrupt_execution()
        {
            _result = (GenericCommandResult)await _handler.Handle(_invalidCommand, cancellationToken);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public async Task When_command_is_invalid_the_result_needs_to_return_StatusCode_NotFound()
        {
            _result = (GenericCommandResult)await _handler.Handle(_invalidCommand, cancellationToken);
            Assert.AreEqual(_result.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_command_is_valid_need_to_execute_Service()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand, cancellationToken);
            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public async Task When_command_is_valid_the_result_needs_to_return_Created()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand, cancellationToken);
            Assert.AreEqual(_result.StatusCode, HttpStatusCode.Created);
        }
    }
}