using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic; //в этом пространстве имён находится нужный класс - коллекция

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupRemovealTests : AuthTestBase
    {

        [Test]
        public void GroupRemovealTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до добавления новой
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            //Список объектов типа GroupData после добавления новой группы
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
