using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWebTests
{
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
        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
    }
}
