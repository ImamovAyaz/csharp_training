using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ContactRemovealTests : AuthTestBase
    {
        [Test]
        public void GontactRemovealTest()
        {
            app.Contacts.Remove(1);
        }
    }
}
