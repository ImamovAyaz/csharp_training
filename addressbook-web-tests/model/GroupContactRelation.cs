using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping; //Mapping - для привязки GroupData с БД

namespace AddressBookWebTests
{
    [Table (Name = "address_in_groups")]
    public class GroupContactRelation
    {
        [Column (Name = "group_id")]
        public string GroupId   //свойство - property
        {
            get;
            set;
        }
        [Column (Name = "id")]
        public string ContactId
        {
            get;
            set;
        }
    }
}
