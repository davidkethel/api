using System.Collections.Generic;
using api.Models.LinqToSql;

namespace api.Models
{
    public interface IJobsRepo
    {
        IEnumerable<Job> getAll();
    }
}
