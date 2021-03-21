using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ContactRemovealTests : AuthTestBase
    {
        [Test]
        public void GontactRemovealTest()
        {
            if (app.Contacts.AvailabilityOfContacts() == false)
            {
                ContactDate contact = new ContactDate("Ayaz1", "Imamov");
                app.Contacts.AddNewContact(contact);
            }
            List<ContactDate> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactDate> newContacts = app.Contacts.GetContactsList();
            ContactDate toBeRemoved = oldContacts[0];
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
