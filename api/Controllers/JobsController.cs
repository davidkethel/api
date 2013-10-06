using api.Models;
using api.Models.LinqToSql;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace api.Controllers
{
    public class JobsController : ApiController
    {

        IGenericRepo<Job> JobsRepo;

        public JobsController()
        {
            JobsRepo = new genericRepo<Job>();
        }

        public JobsController(IGenericRepo<Job> jobsRepo)
        {
            JobsRepo = jobsRepo;
        }


        // GET api/jobs
        public IEnumerable<Job> Get(int? id = 0)
        {
            if (id == 0)
            {
                var allJobs = JobsRepo.getAll();
                if (allJobs != null)
                {
                    return allJobs;
                }
            }
            else
            {
                var allJobs = JobsRepo.getAll().Where(jb => jb.Id == id);
                if (allJobs != null)
                {
                    return allJobs;
                }
            }

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
