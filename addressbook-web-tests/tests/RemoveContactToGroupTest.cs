using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    
    public class RemoveContactToGroupTest : AuthTestBase
    {
        [Test]
        public void TestRemoveContactToGroup()
        {
            //ContactDate contact2 = ContactDate.GetAll()[0];
            //List<GroupData> oldList = contact2.GetGroups();
            //GroupData group = GroupData.GetAll().Except(oldList).First();

            GroupData group = GroupData.GetAll()[0]; //берём группу с нулевым индексом
            List<ContactDate> oldList = group.GetContacts(); //получаем список всех контактов, содержащихся в группе
            //if (oldList.Count == 0)
            //{
            //    foreach (GroupData groups in GroupData.GetAll())
            //    {
            //        if (groups.GetContacts().Count != 0)
            //        {
            //            group = groups;
            //            break;
            //        }
            //    }
            //    ContactDate firstcontact = ContactDate.GetAll()[0];
            //    oldList.Add(firstcontact);
            //}
            //ContactDate contact = ContactDate.GetAll().Except(oldList).First(); //получаем первый попавшийся контакт, который содержится в группе с нулевым индексом
            ContactDate contact = oldList[0];
            // действие

            app.Contacts.RemoveContactToGroup(contact, group);

            List<ContactDate> newList = group.GetContacts();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
