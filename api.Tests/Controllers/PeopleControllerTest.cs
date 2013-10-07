using api.Controllers;
using api.Models;
using api.Models.LinqToSql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Tests.Controllers
{
    [TestClass]
    public class PeopleControllerTest
    {

        #region Basic
        [TestMethod]
        public void TestMethod_EmptyRepo()
        {
            // Arrange

            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();

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

            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
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

            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(peopleList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, peopleList);
        }

        [TestMethod]
        public void TestMethod_3Person()
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


            int Id3 = 13;
            string FirstName3 = "Dave3";
            string LastName3 = "Kethel4";
            System.DateTime DOB3 = new System.DateTime(12, 11, 11);
            string Email3 = "davidkethel43@gmail.com";


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
            },new Person
            {
                Id = Id3,
                FirstName = FirstName3,
                LastName = LastName3,
                DOB = DOB3,
                Email = Email3 ,
            }};

            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(peopleList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, peopleList);
        }

        #endregion

        #region older than
        [TestMethod]
        public void TestMethod_3Person_AgeAbove0()
        {
            // Arrange
            int Id1 = 1;
            string FirstName1 = "Dave";
            string LastName1 = "Kethel";
            System.DateTime DOB1 = DateTime.Now.AddYears(-30);
            string Email1 = "davidkethel@gmail.com";

            int Id2 = 12;
            string FirstName2 = "Dave2";
            string LastName2 = "Kethel3";
            System.DateTime DOB2 = DateTime.Now.AddYears(-23);
            string Email2 = "davidkethel3@gmail.com";


            int Id3 = 13;
            string FirstName3 = "Dave3";
            string LastName3 = "Kethel4";
            System.DateTime DOB3 = DateTime.Now.AddYears(-13);
            string Email3 = "davidkethel43@gmail.com";


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
            },new Person
            {
                Id = Id3,
                FirstName = FirstName3,
                LastName = LastName3,
                DOB = DOB3,
                Email = Email3 ,
            }};

            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(peopleList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get(0).ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, peopleList);
        }

        [TestMethod]
        public void TestMethod_3Person_AgeAbove20_OnePersonExcluded()
        {
            // Arrange
            int Id1 = 1;
            string FirstName1 = "Dave";
            string LastName1 = "Kethel";
            System.DateTime DOB1 = DateTime.Now.AddYears(-130);
            string Email1 = "davidkethel@gmail.com";

            int Id2 = 12;
            string FirstName2 = "Dave2";
            string LastName2 = "Kethel3";
            System.DateTime DOB2 = DateTime.Now.AddYears(-50);
            string Email2 = "davidkethel3@gmail.com";


            int Id3 = 13;
            string FirstName3 = "Dave3";
            string LastName3 = "Kethel4";
            System.DateTime DOB3 = DateTime.Now.AddYears(-5);
            string Email3 = "davidkethel43@gmail.com";


            var repoList = new List<Person>() {new Person
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
            },new Person
            {
                Id = Id3,
                FirstName = FirstName3,
                LastName = LastName3,
                DOB = DOB3,
                Email = Email3 ,
            }};

            var returnList = new List<Person>() {new Person
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


            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(repoList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get(20).ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, returnList);
        }

        [TestMethod]
        public void TestMethod_3Person_AgeAbove20_TwoPersonExcluded()
        {
            // Arrange
            int Id1 = 1;
            string FirstName1 = "Dave";
            string LastName1 = "Kethel";
            System.DateTime DOB1 = DateTime.Now.AddYears(-1);
            string Email1 = "davidkethel@gmail.com";

            int Id2 = 12;
            string FirstName2 = "Dave2";
            string LastName2 = "Kethel3";
            System.DateTime DOB2 = DateTime.Now.AddYears(-50);
            string Email2 = "davidkethel3@gmail.com";


            int Id3 = 13;
            string FirstName3 = "Dave3";
            string LastName3 = "Kethel4";
            System.DateTime DOB3 = DateTime.Now.AddYears(-15);
            string Email3 = "davidkethel43@gmail.com";


            var repoList = new List<Person>() {new Person
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
            },new Person
            {
                Id = Id3,
                FirstName = FirstName3,
                LastName = LastName3,
                DOB = DOB3,
                Email = Email3 ,
            }};

            var returnList = new List<Person>() {
            new Person
            {
                Id = Id2,
                FirstName = FirstName2,
                LastName = LastName2,
                DOB = DOB2,
                Email = Email2 ,
            }};


            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(repoList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get(20).ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, returnList);
        }

        [TestMethod]
        public void TestMethod_3Person_AgeAbove40_OnePersonExcluded()
        {
            // Arrange
            int Id1 = 1;
            string FirstName1 = "Dave";
            string LastName1 = "Kethel";
            System.DateTime DOB1 = DateTime.Now.AddYears(-50);
            string Email1 = "davidkethel@gmail.com";

            int Id2 = 12;
            string FirstName2 = "Dave2";
            string LastName2 = "Kethel3";
            System.DateTime DOB2 = DateTime.Now.AddYears(-46);
            string Email2 = "davidkethel3@gmail.com";


            int Id3 = 13;
            string FirstName3 = "Dave3";
            string LastName3 = "Kethel4";
            System.DateTime DOB3 = DateTime.Now.AddYears(-35);
            string Email3 = "davidkethel43@gmail.com";


            var repoList = new List<Person>() {new Person
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
            },new Person
            {
                Id = Id3,
                FirstName = FirstName3,
                LastName = LastName3,
                DOB = DOB3,
                Email = Email3 ,
            }};

            var returnList = new List<Person>() {new Person
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


            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(repoList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get(40).ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, returnList);
        }

        [TestMethod]
        public void TestMethod_3Person_AgeAbove40_AllPersonExcluded()
        {
            // Arrange
            int Id1 = 1;
            string FirstName1 = "Dave";
            string LastName1 = "Kethel";
            System.DateTime DOB1 = DateTime.Now.AddYears(-5);
            string Email1 = "davidkethel@gmail.com";

            int Id2 = 12;
            string FirstName2 = "Dave2";
            string LastName2 = "Kethel3";
            System.DateTime DOB2 = DateTime.Now.AddYears(-4);
            string Email2 = "davidkethel3@gmail.com";


            int Id3 = 13;
            string FirstName3 = "Dave3";
            string LastName3 = "Kethel4";
            System.DateTime DOB3 = DateTime.Now.AddYears(-35);
            string Email3 = "davidkethel43@gmail.com";


            var repoList = new List<Person>() {new Person
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
            },new Person
            {
                Id = Id3,
                FirstName = FirstName3,
                LastName = LastName3,
                DOB = DOB3,
                Email = Email3 ,
            }};

            var returnList = new List<Person>() { };


            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(repoList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get(40).ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, returnList);
        }

        [TestMethod]
        public void TestMethod_3Person_AgeAbove40_UnderBy1Sec()
        {
            // Arrange
            int Id1 = 1;
            string FirstName1 = "Dave";
            string LastName1 = "Kethel";
            System.DateTime DOB1 = DateTime.Now.AddYears(-50);
            string Email1 = "davidkethel@gmail.com";

            int Id2 = 12;
            string FirstName2 = "Dave2";
            string LastName2 = "Kethel3";
            System.DateTime DOB2 = DateTime.Now.AddYears(-40).AddSeconds(+1);
            string Email2 = "davidkethel3@gmail.com";


            var repoList = new List<Person>() {new Person
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

            var returnList = new List<Person>() { new Person
            {
                Id = Id1,
                FirstName = FirstName1,
                LastName = LastName1,
                DOB = DOB1,
                Email = Email1 ,
            }};


            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(repoList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.Get(40).ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, returnList);
        }

        #endregion


        #region byJob

        [TestMethod]
        public void TestMethod_byJob_EmptyRepo()
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

            var stubPersonRepo = MockRepository.GenerateStub<IGenericRepo<Person>>();
            stubPersonRepo.Stub(x => x.getAll()).Return(peopleList);

            var personController = new PeopleController(stubPersonRepo);

            // Act
            var persons = personController.getByJob(12).ToList();

            // Assert
            CollectionAssert.AreEquivalent(persons, peopleList);
        }


        #endregion

    }
}