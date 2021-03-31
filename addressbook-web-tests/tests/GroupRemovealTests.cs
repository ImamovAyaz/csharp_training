using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic; //в этом пространстве имён находится нужный класс - коллекция

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupRemovealTests : GroupTestBase
    {

        [Test]
        public void GroupRemovealTest()
        {
            if (app.Groups.AvailabilityOfGroups() == false)
            {
                GroupData group = new GroupData("newGroup");
                group.Header = "111";
                group.Footer = "222";
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups = GroupData.GetAll(); //список групп до добавления новой
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            //Список объектов типа GroupData после добавления новой группы
         
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
