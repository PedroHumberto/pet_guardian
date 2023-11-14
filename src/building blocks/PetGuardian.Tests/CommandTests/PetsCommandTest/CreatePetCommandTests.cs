using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuardian.Core.PetGuardianCore.Enums;

namespace PetGuardian.Tests.CommandTests.PetsCommandTest
{
    [TestClass]
    public class CreatePetCommandTests
    {
        private readonly CreatePetCommand _invalidCommand = new CreatePetCommand("L", 'A', AnimalSpecies.Dog, DateTime.Now, 15, Guid.NewGuid());

        private readonly CreatePetCommand _validCommand = new CreatePetCommand("Luci", 'F', AnimalSpecies.Dog, DateTime.Now, 15, Guid.NewGuid());

        [TestMethod]
        public void When_Create_Pet_Is_Invalid()
        {
            _invalidCommand.Execute();
            Assert.AreEqual(_invalidCommand.IsValid, false);
        }
        [TestMethod]
        public void When_Create_Pet_Is_Valid()
        {
            _validCommand.Execute();
            Assert.AreEqual(_validCommand.IsValid, true);
        }
    }
}