using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.LinqToSql
{
    public partial class Person
    {

        public override bool Equals(object other)
        {
            return Equals(other as Person);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + Id;
            hash = hash * 31 + (FirstName == null ? 0 : FirstName.GetHashCode());
            hash = hash * 31 + (LastName == null ? 0 : LastName.GetHashCode());
            hash = hash * 31 + (DOB == null ? 0 : DOB.GetHashCode());
            hash = hash * 31 + (Email == null ? 0 : Email.GetHashCode());
            hash = hash * 31 + Job;
            return hash;
        }

        public bool Equals(Person other)
        {
            if ((object)other == null)
            {
                return false;
            }
            return Id == other.Id
                && FirstName == other.FirstName
                && LastName == other.LastName
                && DOB == other.DOB
                && Email == other.Email
                && Job == other.Job;
        }
    }
}