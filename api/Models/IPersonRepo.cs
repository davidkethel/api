using api.Models.LinqToSql;
using System.Collections.Generic;

namespace api.Models
{
   public interface IPersonRepo
    {
       IEnumerable<Person> getAll();
    }
}
