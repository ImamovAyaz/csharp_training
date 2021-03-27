using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class DetailContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestDetailContactInformation()
        {
            string AllFieldsfromForm = app.Contacts.GetAllFieldsContactInformationFromEditForm(0);
            //ContactDate fromProfile = app.Contacts.GetContactInformationFromProfile(0);
            System.Console.Out.Write(app.Contacts.GetContactInformationFromProfile(0));
            Assert.AreEqual(AllFieldsfromForm.ToString(), app.Contacts.GetContactInformationFromProfile(0));
        }
    }
}
