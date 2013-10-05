using System.Collections.Generic;
using api.Models.LinqToSql;

namespace api.Models
{
    public interface IJobRepo
    {
        IEnumerable<Job> getAll();
    }
}
