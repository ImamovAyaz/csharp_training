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
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTests(GroupData group)
        {
            //GroupData group = new GroupData("aaa");
            //group.Header = "fff";
            //group.Footer = "ggg";
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до добавления новой
            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

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

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

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
