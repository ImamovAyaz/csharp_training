using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {

        [Test]
        public void CreateContactTest()   
        {
            ContactDate contact = new ContactDate("Ayaz1", "Imamov");
            List<ContactDate> oldContacts = app.Contacts.GetContactsList();
            
            app.Contacts.AddNewContact(contact);
            app.Navigator.BackHomePage();
            List<ContactDate> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
        }

        
    }
}
