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
            GroupData group = GroupData.GetAll()[0]; //берём группу с нулевым индексом
            List<ContactDate> oldList = group.GetContacts(); //получаем список всех контактов, содержащихся в группе
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
