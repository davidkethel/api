using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.Models;
using api.Models.LinqToSql;

using Rhino.Mocks;

using System.Collections.Generic;
using System.Linq;

namespace api.Tests.Controllers
{
    [TestClass]
    public class JobsContollerTest
    {

        [TestMethod]
        public void TestMethod_EmptyRepo()
        {
            // Arrange
            var stubJobsRepo = MockRepository.GenerateStub<IJobsRepo>();

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

            var stubJobsRepo = MockRepository.GenerateStub<IJobsRepo>();
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

            var stubJobsRepo = MockRepository.GenerateStub<IJobsRepo>();
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

            var stubJobsRepo = MockRepository.GenerateStub<IJobsRepo>();
            stubJobsRepo.Stub(x => x.getAll()).Return(jobsList);

            var jobsController = new JobsController(stubJobsRepo);

            // Act
            var jobs = jobsController.Get().ToList();

            // Assert
            CollectionAssert.AreEquivalent(jobs, jobsList);
        }

    }
}
