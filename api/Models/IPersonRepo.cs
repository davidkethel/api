using api.Models.LinqToSql;
using System.Data.Linq;

namespace api.Models
{
   public interface IPersonRepo
    {
         Table<Person> getAll();
    }
}
