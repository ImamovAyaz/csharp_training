using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping; //Mapping - для привязки GroupData с БД

namespace AddressBookWebTests
{
    [Table(Name = "group_list")]

    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }
        public GroupData(string name)
        {
            Name = name;
        }
        
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            { //если другой(other) объект равен пустоте, то false
              //так как в объекте который сравниваем есть какое-то значение 100%
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            { //если оба объекта, то есть сравниваемый и другой(other) совпадают, то true
                return true;
            }
            return Name == other.Name;

        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name= " + Name + "\nheader= " + Header + "\nfooter= " + Footer;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_name"), NotNull] //NotNull указываем потому что они в БД для таблицы Null стоят No, то есть данные столбцы не могут иметь пустое поле

        public string Name { get; set; }
        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }
        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity] //Уникальный ключ таблицы
        public string Id { get; set; }
        [Column(Name = "Deprecated")]
        public string Deprecated { get; set; }
        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                //использование языка LINQ
                return (from g in db.Groups select g).ToList(); //возвращает список групп из БД
            }
        }
        public List<ContactDate> GetContacts() //получаем список контактов, который входит в конкретную группу
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                //использование языка LINQ
                return (from c in db.Contacts
                        from GCR in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id 
                        && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList(); //возвращает список групп из БД
            }
        }
        //public static List<GroupContactRelation> GetGroupsToRelations()
        //{
        //    using (AddressbookDB db = new AddressbookDB())
        //    {
        //        //использование языка LINQ
        //        return (from g in db.GCR select g).ToList();
        //    }
        //}
    }
}
