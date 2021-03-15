using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWebTests
{
    public class ContactDate : IEquatable<ContactDate>, IComparable<ContactDate>
    {
        private string firstname;
        private string lastname;

        public ContactDate(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
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
            return (Firstname + Lastname).GetHashCode();
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
            return (Lastname + Firstname).CompareTo(other.Lastname + other.Firstname);
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
    }
}
