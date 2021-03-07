using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactDate newData = new ContactDate("Ayaz123","Imamov123");
            app.Contacts.Modify(1, newData);
        }
    }
}
