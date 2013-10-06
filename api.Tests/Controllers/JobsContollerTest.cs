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
    public class JobsContollerTest
    {
        #region Basic Collection

        [TestMethod]
        public void TestMethod_EmptyRepo()
        {
            // Arrange
            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(new List<Job>());

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(jobs, new List<Job>());
        }

        [TestMethod]
        public void TestMethod_1Job()
        {
            // Arrange
            int id = 34;
            string description = "Softweare Developer";

            var jobsList = new List<Job>{new Job{
                Id = id,
                Description = description
            }};

            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(jobsList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(jobs, jobsList);
        }

        [TestMethod]
        public void TestMethod_2Jobs()
        {
            // Arrange
            int id1 = 34;
            string description1 = "Softweare Developer";

            int id2 = 324;
            string description2 = "2Softweare Developer";


            var jobsList = new List<Job>{new Job{
                Id = id1,
                Description = description1
            },new Job{
                Id = id2,
                Description = description2
            }};

            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(jobsList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(jobs, jobsList);
        }

        [TestMethod]
        public void TestMethod_3Jobs()
        {
            // Arrange
            int id1 = 34;
            string description1 = "Softweare Developer";

            int id2 = 324;
            string description2 = "2Softweare Developer";

            int id3 = 33;
            string description3 = "3Softweare Developer";


            var jobsList = new List<Job>{new Job{
                Id = id1,
                Description = description1
            },new Job{
                Id = id2,
                Description = description2
            },new Job{
                Id = id3,
                Description = description3
            }};

            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(jobsList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(jobs, jobsList);
        }

        #endregion

        #region By Id

        [TestMethod]
        public void TestMethod_ById_EmptyRepo()
        {
            // Arrange
            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(new List<Job>());

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get(3).ToList();

            // Assert
            CollectionAssert.AreEquivalent(jobs, new List<Job>());
        }

        [TestMethod]
        public void TestMethod_ById_NotInRepo()
        {
            // Arrange
            int id = 34;
            string description = "Softweare Developer";

            var jobsList = new List<Job>{new Job{
                Id = id,
                Description = description
            }};

            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(jobsList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get(3).ToList();

            // Assert
            CollectionAssert.AreEquivalent(new List<Job>(), jobs);
        }

        [TestMethod]
        public void TestMethod_ById_InRepo()
        {
            // Arrange
            int id = 34;
            string description = "Softweare Developer";

            var jobsList = new List<Job>{new Job{
                Id = id,
                Description = description
            }};

            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(jobsList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get(34).ToList();

            // Assert
            CollectionAssert.AreEquivalent(jobsList, jobs);
        }

        [TestMethod]
        public void TestMethod_ById_Multiple_NotInRepo()
        {
            // Arrange
            int id1 = 34;
            string description1 = "Softweare Developer";

            int id2 = 324;
            string description2 = "2Softweare Developer";

            int id3 = 33;
            string description3 = "3Softweare Developer";


            var jobsList = new List<Job>{new Job{
                Id = id1,
                Description = description1
            },new Job{
                Id = id2,
                Description = description2
            },new Job{
                Id = id3,
                Description = description3
            }};

            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(jobsList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get(2).ToList();

            // Assert
            CollectionAssert.AreEquivalent(new List<Job>(), jobs);
        }

        [TestMethod]
        public void TestMethod_ById_Multiple_InRepo()
        {
            // Arrange
            int id1 = 34;
            string description1 = "Softweare Developer";

            int id2 = 324;
            string description2 = "2Softweare Developer";

            int id3 = 33;
            string description3 = "3Softweare Developer";


            var repoList = new List<Job>{new Job{
                Id = id1,
                Description = description1
            },new Job{
                Id = id2,
                Description = description2
            },new Job{
                Id = id3,
                Description = description3
            }};

            var returnList = new List<Job>{new Job{
                Id = id3,
                Description = description3
            }};


            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(repoList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get(33).ToList();

            // Assert
            CollectionAssert.AreEquivalent(returnList, jobs);
        }

        [TestMethod]
        public void TestMethod_ById_Multiple_Id0()
        {
            // Arrange
            int id1 = 34;
            string description1 = "Softweare Developer";

            int id2 = 324;
            string description2 = "2Softweare Developer";

            int id3 = 33;
            string description3 = "3Softweare Developer";


            var jobsList = new List<Job>{new Job{
                Id = id1,
                Description = description1
            },new Job{
                Id = id2,
                Description = description2
            },new Job{
                Id = id3,
                Description = description3
            }};

            var stubJobsRepo = MockRepository.GenerateStub<IGenericRepo<Job>>();
            stubJobsRepo.Stub(x => x.getAll()).Return(jobsList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get(0).ToList();

            // Assert
            CollectionAssert.AreEquivalent(jobsList, jobs);
        }

        #endregion

    }
}
