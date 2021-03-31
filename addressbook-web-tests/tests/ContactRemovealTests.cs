using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ContactRemovealTests : ContactTestBase
    {
        [Test]
        public void GontactRemovealTest()
        {
            if (app.Contacts.AvailabilityOfContacts() == false)
            {
                ContactDate contact = new ContactDate("Ayaz1", "Imamov");
                app.Contacts.AddNewContact(contact);
            }
            List<ContactDate> oldContacts = ContactDate.GetAll();
            ContactDate toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);
            
            
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            Thread.Sleep(3000);
            List<ContactDate> newContacts = ContactDate.GetAll();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactDate contact in newContacts)
            {
                Assert.AreEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
