using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace AddressBookWebTests
{
    public class AddressbookDB : LinqToDB.Data.DataConnection //Для представления класса как БД, необходимо сделать его дочерним классом данного класса
    {
        public AddressbookDB() : base("AddressBook")
        {
        }
        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<ContactDate> Contacts { get { return GetTable<ContactDate>(); } }

        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } } // извлекаем данные из таблицы БД 

    }
}