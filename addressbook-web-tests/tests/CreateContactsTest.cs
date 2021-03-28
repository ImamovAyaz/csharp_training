using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
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
                    Middlename = GenerateRandomString(50),
                    Address = GenerateRandomString(50),
                    Company = GenerateRandomString(50),
                    AllEmails = GenerateRandomString(50)
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactDate> ContactDataFromCsvFile()
        {
            List<ContactDate> contacts = new List<ContactDate>();
            string[] lines = File.ReadAllLines("@contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactDate(parts[0], parts[1])
                {
                    Middlename = parts[3],
                    Address = parts[4],
                    Company = parts[5],
                    AllEmails = parts[6]
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactDate> ContactDataFromXmlFile()
        {
            return (List<ContactDate>)
                new XmlSerializer(typeof(List<ContactDate>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<ContactDate> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactDate>>
                (File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
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
