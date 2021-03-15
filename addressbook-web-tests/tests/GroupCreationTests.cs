using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic; //в этом пространстве имён находится нужный класс - коллекция
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupCreationTestNew : AuthTestBase
    {
        [Test]
        public void GroupCreationTests()
        {            
            GroupData group = new GroupData("aaa");
            group.Header = "fff";
            group.Footer = "ggg";
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до добавления новой
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            //Список объектов типа GroupData после добавления новой группы
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //сравнение двух списков
            app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до добавления новой
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            //Список объектов типа GroupData после добавления новой группы
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //сравнение двух списков
            app.Auth.Logout();
        }

        [Test]
        public void BadNameGroupCreationTests()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до добавления новой
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            //Список объектов типа GroupData после добавления новой группы
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //сравнение двух списков
            app.Auth.Logout();
        }
    }
}
