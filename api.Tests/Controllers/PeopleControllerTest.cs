using api.Controllers;
using api.Models;
using api.Models.LinqToSql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace api.Tests.Controllers
{
    [TestClass]
    public class PeopleControllerTest
    {
        [TestMethod]
        public void TestMethod_EmptyRepo()
        {
            // Arrange

            var stubPersonRepo = MockRepository.GenerateStub<IPersonRepo>();

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, new List<Person>());
        }


        [TestMethod]
        public void TestMethod_1Person()
        {
            // Arrange
            int Id = 1;
            string FirstName = "Dave";
            string LastName = "Kethel";
            System.DateTime DOB = new System.DateTime(11, 11, 11);
            string _Email = "davidkethel@gmail.com";

            var peopleList = new List<Person>() {new Person
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                DOB = DOB,
                Email = _Email
            }};

            var stubPersonRepo = MockRepository.GenerateStub<IPersonRepo>();
            stubPersonRepo.Stub(x => x.getAll()).Return(peopleList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, peopleList);
        }


    }
}