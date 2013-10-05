using api.Models.LinqToSql;
using System.Collections.Generic;

namespace api.Models
{
   public interface IPeopleRepo
    {
       IEnumerable<Person> getAll();
    }
}
