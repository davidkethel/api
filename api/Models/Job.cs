using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.LinqToSql
{
    public partial class Job
    {
        public override bool Equals(object other)
        {
            return Equals(other as Job);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + Id;
            hash = hash * 31 + (Description == null ? 0 : Description.GetHashCode());
            return hash;
        }

        public bool Equals(Job other)
        {
            if ((object)other == null)
            {
                return false;
            }
            return Id == other.Id
                && Description == other.Description;
        }

    }
}