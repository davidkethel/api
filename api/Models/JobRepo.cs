using System.Collections.Generic;

namespace api.Models.LinqToSql
{
    public class JobRepo : IJobRepo
    {
        private DataDataContext DB = new DataDataContext();
        
        public IEnumerable<Job> getAll()
        {

            return DB.Jobs;
        }
    }
}