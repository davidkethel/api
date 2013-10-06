using api.Models;
using api.Models.LinqToSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace api.Controllers
{
    public class PeopleController : ApiController
    {


        IGenericRepo<Person> personRepo;

        public PeopleController()
        {
            personRepo = new genericRepo<Person>();
        }

        public PeopleController(IGenericRepo<Person> perRepo)
        {
            personRepo = perRepo;
        }

        // GET api/person
        public IEnumerable<Person> Get(int? olderThan = 0)
        {
            var allPeople = personRepo.getAll();

            if (allPeople != null)
            {
                return personRepo.getAll().Where(per => per.DOB < DateTime.Now.AddYears(-olderThan.Value));
            }
            else
            {
                return new List<Person>();
            }
        }

        //// GET api/person/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/person
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/person/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/person/5
        //public void Delete(int id)
        //{
        //}
    }
}
