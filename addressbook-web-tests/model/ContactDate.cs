using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWebTests
{
    public class ContactDate : IEquatable<ContactDate>, IComparable<ContactDate>
    {
        private string allPhones;
        private string allEmails;

        public ContactDate(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
        public bool Equals(ContactDate other)
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

        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("+", "").Replace("(", "").Replace(")", "") + "\r\n";
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return Email + Email2 + Email3;
                }
            }
            set
            {
                allEmails = value;
            }
        }
    }

}

