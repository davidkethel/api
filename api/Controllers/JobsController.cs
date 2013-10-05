using api.Models;
using api.Models.LinqToSql;
using System.Collections.Generic;
using System.Web.Http;

namespace api.Controllers
{
    public class JobsController : ApiController
    {
        IJobsRepo JobsRepo;


        public JobsController()
        {
            JobsRepo = new JobsRepo();
        }

        public JobsController(IJobsRepo jobsRepo)
        {
            JobsRepo = jobsRepo;
        }


        // GET api/jobs
        public IEnumerable<Job> Get()
        {
            return new List<Job>();
        }

        //// GET api/jobs/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/jobs
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/jobs/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/jobs/5
        //public void Delete(int id)
        //{
        //}
    }
}
