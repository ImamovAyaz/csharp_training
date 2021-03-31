using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase // Тесты наследуются от базового тестового класса
    {
        [Test]
        public void GroupModificationTest()  // тестовый метод
        {
            if (app.Groups.AvailabilityOfGroups() == false)
            {
                GroupData group = new GroupData("newGroup");
                group.Header = "111";
                group.Footer = "222";
                app.Groups.Create(group);
            }
            GroupData newData = new GroupData("aaa1231");
            newData.Header = null;
            newData.Footer = null;
            List<GroupData> oldGroups = GroupData.GetAll(); //список групп до добавления новой
            GroupData oldData = oldGroups[0];
            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            //Список объектов типа GroupData после добавления новой группы
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //сравнение двух списков

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

    }
}
