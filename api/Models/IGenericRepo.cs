using System.Collections.Generic;

namespace api.Models
{
   public interface IGenericRepo<elem> where elem : class
    {
        IEnumerable<elem> getAll();
    }
}
