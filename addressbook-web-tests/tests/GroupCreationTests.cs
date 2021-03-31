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
using Excel = Microsoft.Office.Interop.Excel; //Библиотека для взаимодействия с Эксель
using System.Linq;


namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupCreationTestNew : GroupTestBase
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
        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application(); //создаём приложение
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet; //текущая страница
            Excel.Range range = sheet.UsedRange; //область прямоугольника который содержит данные в файле Эксель (Например: 3 на 3)
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromExcelFile")]
        public void GroupCreationTests(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAll(); //список групп до добавления новой
            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
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
            List<GroupData> oldGroups = GroupData.GetAll(); //список групп до добавления новой
            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            //Список объектов типа GroupData после добавления новой группы
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Thread.Sleep(3000);
            Assert.AreEqual(oldGroups, newGroups); //сравнение двух списков
            app.Auth.Logout();
        }

        [Test]
        public void TestDBConnectivityForGroup()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList(); //читаем группы из интерфейса
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start)); //Из конца вычитаем то что в начале
            start = DateTime.Now;

            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}
