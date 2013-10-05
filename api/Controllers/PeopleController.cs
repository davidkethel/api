using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api.Models.LinqToSql;
using api.Models;

namespace api.Controllers
{
    public class PeopleController : ApiController
    {

        IPersonRepo personRepo;


        public PeopleController()
        {
            personRepo = new PersonRepo();
        }

        public PeopleController(IPersonRepo perRepo)
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
