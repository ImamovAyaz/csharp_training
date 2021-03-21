﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.AvailabilityOfContacts() == false)
            {
                ContactDate contact = new ContactDate("Ayaz1", "Imamov");
                app.Contacts.AddNewContact(contact);
            }
            ContactDate newData = new ContactDate("Ayaz123","Imamov123");
            List<ContactDate> oldContacts = app.Contacts.GetContactsList();
            ContactDate oldData = oldContacts[0];
            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactDate> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactDate contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname, oldData.Firstname);
                    Assert.AreEqual(contact.Lastname, oldData.Lastname);
                }
            }
        }
    }
}
