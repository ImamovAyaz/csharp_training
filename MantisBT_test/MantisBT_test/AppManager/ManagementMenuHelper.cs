using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisBT_test
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }
        public void OpenHomePage()
        {
            if (driver.Url == "http://localhost/mantisbt-2.25.0/my_view_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.0/my_view_page.php");
        }

        public void LoginPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.0/login_page.php";
        }

        public void OpenProjectPage()
        {
            if (driver.Url == "http://localhost/mantisbt-2.25.0/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.0/manage_proj_page.php");
        }
    }
}
