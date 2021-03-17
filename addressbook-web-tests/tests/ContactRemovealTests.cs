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
            List<ContactDate> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
