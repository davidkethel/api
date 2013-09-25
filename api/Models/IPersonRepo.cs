using api.Models.LinqToSql;
using System.Data.Linq;

namespace api.Models
{
    interface IPersonRepo
    {
        public Table<Person> getAll();
    }
}
