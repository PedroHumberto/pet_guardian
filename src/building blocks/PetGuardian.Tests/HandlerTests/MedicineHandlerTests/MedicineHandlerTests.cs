using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetGuadian.Application.Commands.MedicineCommands;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Handlers.Medicines;
using PetGuardian.Tests.Services;

namespace PetGuardian.Tests.HandlerTests.MedicineHandlerTests
{
    [TestClass]
    public class MedicineHandlerTests
    {
        private readonly CreateMedicineCommand _invalidCommand = new CreateMedicineCommand("Re", "1556 asd", "asd", DateTime.UtcNow, DateTime.UtcNow, Guid.NewGuid());
        private readonly CreateMedicineCommand _validCommand = new CreateMedicineCommand("Azitromicine", "1556 asd", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX", DateTime.UtcNow, DateTime.UtcNow, Guid.NewGuid());
        private readonly CreateMedicineHandler _handler = new CreateMedicineHandler(new FakeMedicineRepository());
        private readonly CancellationToken cancellationToken = new CancellationToken();
        private GenericCommandResult _result = new GenericCommandResult();

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
        public async Task When_command_is_valid_need_to_execute_Repository()
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