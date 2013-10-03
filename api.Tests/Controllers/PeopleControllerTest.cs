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
                Email = _Email ,
            }};

            var stubPersonRepo = MockRepository.GenerateStub<IPersonRepo>();
            stubPersonRepo.Stub(x => x.getAll()).Return(peopleList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, peopleList);
        }

        [TestMethod]
        public void TestMethod_2Person()
        {
            // Arrange
            int Id1 = 1;
            string FirstName1 = "Dave";
            string LastName1 = "Kethel";
            System.DateTime DOB1 = new System.DateTime(11, 11, 11);
            string Email1 = "davidkethel@gmail.com";

            int Id2 = 12;
            string FirstName2 = "Dave2";
            string LastName2 = "Kethel3";
            System.DateTime DOB2 = new System.DateTime(13, 11, 11);
            string Email2 = "davidkethel3@gmail.com";


            var peopleList = new List<Person>() {new Person
            {
                Id = Id1,
                FirstName = FirstName1,
                LastName = LastName1,
                DOB = DOB1,
                Email = Email1 ,
            },
            new Person
            {
                Id = Id2,
                FirstName = FirstName2,
                LastName = LastName2,
                DOB = DOB2,
                Email = Email2 ,
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