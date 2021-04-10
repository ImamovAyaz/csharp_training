using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading;


namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void TestRemoveGroup()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count == 1)
            {
                GroupData newGroup = new GroupData
                {
                    Name = "testNew"
                };
                app.Groups.Add(newGroup);
                oldGroups = app.Groups.GetGroupList();
            }
            app.Groups.Remove(0);
            Thread.Sleep(3000);
            List<GroupData> newGroups = app.Groups.GetGroupList();         
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
