using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();

        }

        public void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector(".back-to-login-link.pull-left")).Click();
            //manager.Driver.Url = "http://localhost/mantisbt-2.25.0/mantisbt-2.25.0/signup_page.php";
        }

        public void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector(".width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();
        }

        public void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.0/login_page.php";
        }
    }
}
