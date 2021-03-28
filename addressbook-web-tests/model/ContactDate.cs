using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressBookWebTests
{
    public class ContactDate : IEquatable<ContactDate>, IComparable<ContactDate>
    {
        private string allPhones;
        private string allEmails;
        private string allInfosInProfile;
        public ContactDate()
        {
        }
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
            return "\nLastname = " + Lastname + "," + "\nFirstname =" + Firstname + "\nAddress = " + Address;
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
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string FullName
        {
            get
            {
                if (FullName != null)
                {
                    return FullName;
                }
                else
                {
                    return Firstname + Middlename + Lastname;
                }
            }
            set
            {
                FullName = value;
            }
        }
        public string Nickname { get; set; }
        public string Id { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }

        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Homepage
        {
            get
            {
                if (Homepage != null)
                {
                    return Homepage;
                }
                else
                {
                    return "Homepage:" + Homepage;
                }
            }
            set
            {
                Homepage = value;
            }
        }
        public string DayOfBirthday
        {
            get
            {
                if (DayOfBirthday != null)
                {
                    return DayOfBirthday;
                }
                else
                {
                    return DayOfBirthday + ". ";
                }
            }
            set
            {
                DayOfBirthday = value;
            }
        }
        public string MonthOfBirthday
        {
            get
            {
                if (MonthOfBirthday != null)
                {
                    return MonthOfBirthday;
                }
                else
                {
                    return MonthOfBirthday + " ";
                }
            }
            set
            {
                MonthOfBirthday = value;
            }
        }
        public string YearOfBirthday
        {
            get
            {
                int dateTime = DateTime.Now.Year;
                if ((YearOfBirthday != null) || ((Convert.ToInt32(DayOfBirthday) == DateTime.Now.Day) &&
                                                (Convert.ToInt32(MonthOfBirthday) == DateTime.Now.Day) &&
                                                (Convert.ToInt32(YearOfBirthday) == DateTime.Now.Year)))
                {
                    return YearOfBirthday;
                }
                else
                {               
                    return YearOfBirthday + " (" + (dateTime - Convert.ToInt32(YearOfBirthday) + ")");
                }
            }
            set
            {
                YearOfBirthday = value;
            }
        }
        public string BirthDay
        {
            get
            {
                if (BirthDay != null)
                {
                    return BirthDay;
                }
                else
                {
                    return "Birthday " + DayOfBirthday + MonthOfBirthday + YearOfBirthday;
                }
            }
            set
            {
                BirthDay = value;
            }
        } 
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
                return Regex.Replace(phone, "[ -()]", " ") + "\r\n";
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
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllInfosInProfile
        {
            get
            {
                if (allInfosInProfile != null)
                {
                    return allInfosInProfile;
                }
                else
                {
                    return CleanUp(AllInfosInProfile);
                }
            }
            set
            {
                allInfosInProfile = value;
            }
        }
    }

}

