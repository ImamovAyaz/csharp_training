using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBookWebTests
{
    public class LoginHelper : HelperBase
    {
       

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn()) //Проверка, залогинен ли пользователь и под каким пользователем
            {
                if (IsLoggedIn(account)) //Залогинены ли мы тем пользователем, которого передали 
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
        public bool IsLoggedIn()  // Метод возвращающий наименование элемента,
                                  // который говорит о том что пользователь зарег-ан
        {
            return IsElementPresent(By.Name("logout"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                    == "(" + account.Username + ")";
        }
    }

}
