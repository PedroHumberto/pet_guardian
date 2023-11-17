using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetGuadian.Application.Commands.MedicineCommands;

namespace PetGuardian.Tests.CommandTests.MedicineCommandTests
{
    [TestClass]
    public class CreateMedicineCommandTests
    {
        private readonly CreateMedicineCommand _invalidCommand = new CreateMedicineCommand("R", "1556 asd", "asd", DateTime.UtcNow, DateTime.UtcNow, Guid.NewGuid());
        private readonly CreateMedicineCommand _validCommand = new CreateMedicineCommand("Azitromicine", "1556 asd", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX", DateTime.UtcNow, DateTime.UtcNow, Guid.NewGuid());
        [TestMethod]
        public void If_Command_Is_Invalid_Return_False()
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