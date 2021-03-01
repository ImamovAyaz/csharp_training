using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace GroupCreationTestsNew
{
    [TestFixture]
    public class Contact : TestBase
    {

        [Test]
        public void TheContactTest()   // привести в порядок тестовую группу
        {
            ContactDate contact = new ContactDate("Ayaz1", "Imamov");
            app.Contacts.AddNewContact(contact);
            app.Navigator.BackHomePage();
        }

        
    }
}
