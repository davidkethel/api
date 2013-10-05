using System.Collections.Generic;

namespace api.Models.LinqToSql
{
    public class JobsRepo : IJobsRepo
    {
        private DataDataContext DB = new DataDataContext();
        
        public IEnumerable<Job> getAll()
        {

            return DB.Jobs;
        }
    }
}