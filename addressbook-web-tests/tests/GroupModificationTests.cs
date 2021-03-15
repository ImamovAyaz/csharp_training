using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase // Тесты наследуются от базового тестового класса
    {
        [Test]
        public void GroupModificationTest()  // тестовый метод
        {
            GroupData newData = new GroupData("aaa123");
            newData.Header = null;
            newData.Footer = null;
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до добавления новой

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            //Список объектов типа GroupData после добавления новой группы
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //сравнение двух списков
        }

    }
}
