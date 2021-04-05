using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AddressBookWebTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = new GroupData();
            List<GroupData> groups = GroupData.GetAll(); //берём группу с нулевым индексом
            if (groups.Count == 0)
            {
                GroupData addgroup = new GroupData(GenerateRandomString(10));
                app.Groups.Create(addgroup);
                group = GroupData.GetAll()[0];
            }
            else
            {
                group = GroupData.GetAll()[0];
            }
            List<ContactDate> AllContacts = ContactDate.GetAll();          
            if (AllContacts.Count == 0)
            {
                ContactDate Addcontact = new ContactDate(GenerateRandomString(50), GenerateRandomString(100));
                app.Contacts.AddNewContact(Addcontact);
                AllContacts = group.GetContacts();
            }
            List<ContactDate> oldList = group.GetContacts();
            if (ContactDate.GetAll().Except(oldList).FirstOrDefault() == null)
            {

                ContactDate Addcontact = new ContactDate(GenerateRandomString(50), GenerateRandomString(100));
                app.Contacts.AddNewContact(Addcontact);
                //group = GroupData.GetAll()[0];
            }
            oldList = group.GetContacts(); //получаем список всех контактов, содержащихся в группе
            ContactDate contact = ContactDate.GetAll().Except(oldList).First(); //получаем первый попавшийся контакт, который содержится в группе с нулевым индексом

            // действия 
            app.Contacts.AddContactToGroup(contact, group); //метод добавления контакта в группу, которые принимает соответственно контакт, который необходимо добавить и группу, куда надо это сделать

            List<ContactDate> newList = group.GetContacts(); //записываем получившуюся группу
            oldList.Add(contact); //добавляем к старому списку тот контакт, который добавили в конкретную группу
            newList.Sort(); //сортировочка, чтобы оба списка были в одном порядке
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
