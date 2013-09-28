using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.Models.LinqToSql;
using System.Linq;
using Rhino;
using Rhino.Mocks;
using api.Models;

namespace api.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange

            var stubPersonRepo = MockRepository.GenerateStub<IPersonRepo>();
            
            var personController = new PersonController(stubPersonRepo);

            // Act
            var persons = personController.Get();

            // Assert
            Assert.AreEqual(persons.FirstOrDefault().FirstName, "Dave");

        }
    }
}