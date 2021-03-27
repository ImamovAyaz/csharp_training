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
        public static IEnumerable<ContactDate> RandomContactDataProvider()
        {
            List<ContactDate> contacts = new List<ContactDate>();
            for (int i = 0; i < 3; i++) //задаём количество тестов, которые будут сгенерированы рандомными данными
            {
                contacts.Add(new ContactDate(GenerateRandomString(50), GenerateRandomString(100))
                {
                    Address = GenerateRandomString(50)
                }) ;
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateContactTest(ContactDate contact)   
        {
         //   ContactDate contact = new ContactDate("Ayaz1", "Imamov");
            List<ContactDate> oldContacts = app.Contacts.GetContactsList();
            
            app.Contacts.AddNewContact(contact);
            app.Navigator.BackHomePage();

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactDate> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
        }

        
    }
}
