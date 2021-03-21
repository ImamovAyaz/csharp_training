using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace AddressBookWebTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert = true;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveContact();
            return this;
        }

 

        private List<ContactDate> contactCash = null;
        public List<ContactDate> GetContactsList()
        {
            if (contactCash == null)
            {
                contactCash = new List<ContactDate>();
                manager.Navigator.GoToHomePage();
                IList<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
                string firstname;
                string lastname;
                foreach (IWebElement element in elements)
                {
 
                    IList<IWebElement> cells = element.FindElements(By.CssSelector("td"));
                    lastname = cells[2].Text;
                    firstname = cells[1].Text;
                    contactCash.Add(new ContactDate(lastname, firstname)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }            
            }
            List<ContactDate> contact = new List<ContactDate>();
            return new List<ContactDate>(contactCash);
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCash = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper Modify(int v, ContactDate newData)
        {
            manager.Navigator.GoToHomePage();
            EditThisContact(v);
            FillContactForm(newData);
            UpdateContact(v);
            manager.Navigator.GoToHomePage();
            return this;
        }
        public ContactHelper AddNewContact(ContactDate contact)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCash = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelper EditThisContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactDate contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper UpdateContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[" + (index + 1) + "]")).Click();
            contactCash = null;
            return this;
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        public bool AvailabilityOfContacts()
        {
            return IsElementPresent(By.Name("entry"));
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name=\"entry\"]")).Count;
        }
    }
}
