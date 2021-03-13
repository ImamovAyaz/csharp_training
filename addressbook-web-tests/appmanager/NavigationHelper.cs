using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBookWebTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL = "http://localhost/addressbook";
        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            if ((driver.Url == baseURL + "/group.php") 
                && (IsElementPresent(By.Name("new"))))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void BackHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
