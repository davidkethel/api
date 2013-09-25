using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api.Models.LinqToSql;

namespace api.Controllers
{
    public class PersonController : ApiController
    {
        // GET api/person
        public IEnumerable<Person> Get()
        {
            var per = new Person();
            per.FirstName = "Dave";
            per.LastName = "Bill";
            per.DOB = new DateTime(11, 11, 11, 11, 11, 11);

            return new List<Person> { per };
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
