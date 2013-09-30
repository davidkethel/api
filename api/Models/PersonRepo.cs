using api.Models.LinqToSql;
using System.Collections.Generic;

namespace api.Models
{
    public class PersonRepo : IPersonRepo
    {
        private DataDataContext DB = new DataDataContext();

        public IEnumerable<Person> getAll()
        {
            return DB.Persons;
        }
    }
}