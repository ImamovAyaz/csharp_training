using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping; //Mapping - для привязки GroupData с БД

namespace AddressBookWebTests
{
    [Table(Name = "addressbook")]
    public class ContactDate : IEquatable<ContactDate>, IComparable<ContactDate>
    {
        private string allPhones;
        private string allEmails;
        private string allInfosInProfile;
        private string homepage;
        private string fullName;
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
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                {
                    return Firstname + Middlename + Lastname;
                }
            }
            set
            {
                fullName = value;
            }
        }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }
        [Column(Name = "fax")]
        public string Fax { get; set; }
        public string Homepage
        {
            get
            {
                if (homepage != null)
                {
                    return homepage;
                }
                else
                {
                    return "Homepage:" + homepage;
                }
            }
            set
            {
                homepage = value;
            }
        }

        [Column(Name = "Deprecated")]
        public string Deprecated { get; set; }
        //public string DayOfBirthday
        //{
        //    get
        //    {
        //        if (DayOfBirthday != null)
        //        {
        //            return DayOfBirthday;
        //        }
        //        else
        //        {
        //            return DayOfBirthday + ". ";
        //        }
        //    }
        //    set
        //    {
        //        DayOfBirthday = value;
        //    }
        //}
        //public string MonthOfBirthday
        //{
        //    get
        //    {
        //        if (MonthOfBirthday != null)
        //        {
        //            return MonthOfBirthday;
        //        }
        //        else
        //        {
        //            return MonthOfBirthday + " ";
        //        }
        //    }
        //    set
        //    {
        //        MonthOfBirthday = value;
        //    }
        //}
        //public string YearOfBirthday
        //{
        //    get
        //    {
        //        int dateTime = DateTime.Now.Year;
        //        if ((YearOfBirthday != null) || ((Convert.ToInt32(DayOfBirthday) == DateTime.Now.Day) &&
        //                                        (Convert.ToInt32(MonthOfBirthday) == DateTime.Now.Day) &&
        //                                        (Convert.ToInt32(YearOfBirthday) == DateTime.Now.Year)))
        //        {
        //            return YearOfBirthday;
        //        }
        //        else
        //        {               
        //            return YearOfBirthday + " (" + (dateTime - Convert.ToInt32(YearOfBirthday) + ")");
        //        }
        //    }
        //    set
        //    {
        //        YearOfBirthday = value;
        //    }
        //}
        //public string BirthDay
        //{
        //    get
        //    {
        //        if (BirthDay != null)
        //        {
        //            return BirthDay;
        //        }
        //        else
        //        {
        //            return "Birthday " + DayOfBirthday + MonthOfBirthday + YearOfBirthday;
        //        }
        //    }
        //    set
        //    {
        //        BirthDay = value;
        //    }
        //} 
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
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
        public string CleanUp(string parameter)
        {
            if (parameter == null || parameter == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(parameter, "[ -()]", " ") + "\r\n";
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
        //public string AllInfosInProfile
        //{
        //    get
        //    {
        //        if (allInfosInProfile != null)
        //        {
        //            return CleanUp(allInfosInProfile);
        //        }
        //        else
        //        {
        //            return CleanUp(AllInfosInProfile);
        //        }
        //    }
        //    set
        //    {
        //        allInfosInProfile = value;
        //    }
        //}
        public static List<ContactDate> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                //использование языка LINQ
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList(); //возвращает список групп из БД
                // выше в блоке Where показано лямбда выражение, внутри которого x - параметр, а далее - тело функции, которое возвращает величину bool
            }
        }
        public List<GroupData> GetGroups() //получаем список контактов, который входит в конкретную группу
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                //использование языка LINQ
                return (from g in db.Groups
                        from GCR in db.GCR.Where(p => p.GroupId == Id && p.ContactId == g.Id
                        && g.Deprecated == "0000-00-00 00:00:00")
                        select g).Distinct().ToList(); //возвращает список групп из БД
            }
        }

    }

}

