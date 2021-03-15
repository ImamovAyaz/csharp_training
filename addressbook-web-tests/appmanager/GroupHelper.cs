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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }
        public GroupHelper Create(GroupData group) //метод для создания групп
        {
            manager.Navigator.GoToGroupsPage();
            CreateNewGroup();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements) // для каждого element из elements выполняем
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage(); //переход на нужную нам страницу
            if (AvailabilityOfGroups() == false)
            {
                GroupData group = new GroupData("newGroup");
                group.Header = "111";
                group.Footer = "222";
                Create(group);
            }
            SelectGroup(v);
            InitGroupModification(); 
            FillGroupForm(newData); // заполняем появившуюся форму
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public bool AvailabilityOfGroups()
        {
            return IsElementPresent(By.Name("selected[]"));   
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            if (AvailabilityOfGroups() == false)
            {
                GroupData group = new GroupData("newGroup");
                group.Header = "111";
                group.Footer = "222";
                Create(group);
            }
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper CreateNewGroup()
        {
            // Create new group
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }



        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
