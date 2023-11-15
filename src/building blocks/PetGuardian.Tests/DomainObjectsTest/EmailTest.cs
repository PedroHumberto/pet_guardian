using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Tests.DomainObjectsTest
{
    [TestClass]
    public class EmailTest
    {
        private readonly string _invalidEmail = "teste@.com";
        private readonly string _validEmail = "teste@email.com";
        

        [TestMethod]
        public void Constructor_InvalidEmail_ThrowsException()
        {
            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Email(_invalidEmail), "Invalid Email");
        }

        [TestMethod]
        public void Constructor_ValidEmail_CreatesEmailObject()
        {
            // Act
            var email = new Email(_validEmail);

            // Assert
            Assert.IsNotNull(email);
            Assert.AreEqual(_validEmail, email.EmailAddress);
        }
    }
}