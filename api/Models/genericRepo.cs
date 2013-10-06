using System.Collections.Generic;

namespace api.Models.LinqToSql
{
    public class genericRepo<elem> : IGenericRepo<elem> where elem : class
    {
        private DataDataContext DB = new DataDataContext();


        public IEnumerable<elem> getAll()
        {
            return DB.GetTable<elem>();
        }
    }
}