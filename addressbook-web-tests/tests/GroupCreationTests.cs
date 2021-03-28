using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
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
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv"); //записываем данные из файла в массив строк
            foreach (string l in lines)
            {
                string[] parts = l.Split(','); //разделяем данные по ячейкам массива, через символ ","
                groups.Add(new GroupData(parts[0]) //добавляем объект Группа, с 0,1 и 2 элементов из массивов
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) //приведение в тип списка типа ГруппДата, так как Deserialize возвращать иной тип
                new XmlSerializer(typeof(List<GroupData>)) //читаем данные типа лист оф группдата из файла groups.xml
                    .Deserialize(new StreamReader(@"groups.xml"));
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }
        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTests(GroupData group)
        {
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
            Thread.Sleep(3000);
            Assert.AreEqual(oldGroups, newGroups); //сравнение двух списков
            app.Auth.Logout();
        }
    }
}
