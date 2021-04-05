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
            GroupData group = new GroupData();
            List<GroupData> groups = GroupData.GetAll(); //берём группу с нулевым индексом
            if (groups.Count == 0)
            {
                GroupData addgroup = new GroupData(GenerateRandomString(10));
                app.Groups.Create(addgroup);
                group = GroupData.GetAll()[0]; //берём группу с нулевым индексом
            }
            else
            {
                group = GroupData.GetAll()[0]; //берём группу с нулевым индексом
            }
            List<ContactDate> AllContacts = ContactDate.GetAll();
            if (AllContacts.Count == 0)
            {
                ContactDate Addcontact = new ContactDate(GenerateRandomString(50), GenerateRandomString(100));
                app.Contacts.AddNewContact(Addcontact);
                AllContacts = group.GetContacts();
            }
            List<ContactDate> oldList = group.GetContacts(); //получаем список всех контактов, содержащихся в группе
            //ContactDate Contacts = ContactDate.GetAll().Except(oldList).FirstOrDefault();
            if ((ContactDate.GetAll().Except(oldList).FirstOrDefault() == null) || (oldList.Count == 0))
            {

                ContactDate Addcontact = new ContactDate(GenerateRandomString(50), GenerateRandomString(100));
                app.Contacts.AddNewContact(Addcontact);
                Addcontact = ContactDate.GetAll().Except(oldList).First();
                app.Contacts.AddContactToGroup(Addcontact, group);
                //group = GroupData.GetAll()[0];
            }
            oldList = group.GetContacts();
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
