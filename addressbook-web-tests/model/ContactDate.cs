using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWebTests
{
    public class ContactDate : IEquatable<ContactDate>, IComparable<ContactDate>
    {

        public ContactDate(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
        public bool Equals (ContactDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname + Lastname == other.Firstname + other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "Lastname = " + Lastname + "," + "Firstname =" + Firstname;
        }
        public int CompareTo(ContactDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Firstname.CompareTo(other.Firstname);
        }
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        
        public string Id { get; set; }
    }
}
