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
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactDate newData = new ContactDate("Ayaz123","Imamov123");
            List<ContactDate> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Modify(0, newData);
            List<ContactDate> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
