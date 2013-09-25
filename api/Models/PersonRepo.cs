using api.Models.LinqToSql;
using System.Data.Linq;

namespace api.Models
{
    public class PersonRepo : IPersonRepo
    {
        private DataDataContext DB = new DataDataContext();

        public Table<Person> getAll()
        {
            return DB.Persons;
        }
    }
}