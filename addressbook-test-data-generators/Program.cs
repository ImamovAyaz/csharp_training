using System;
using AddressBookWebTests;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeData = args[0]; //выбираем, contact или group
            int count = Convert.ToInt32(args[1]); //аргумент 1 -Количество тестjвых данных, которые хотим сгенерировать
            //Для записи в текстовый файл используется класс StreamWriter.
            StreamWriter writer = new StreamWriter(args[2]); // аргумент 2 - Название файла, в который будем писать сгенерированные данные
            string format = args[3];

            if (typeData == "groups")
            {
                List<GroupData> groups = new List<GroupData>(); //список groups, в который будут записываться случайные строки
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognixed format " + format);
                }
                writer.Close();
            }
            else if (typeData == "contacts")
            {
                List<ContactDate> contacts = new List<ContactDate>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactDate(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(10),
                        Middlename = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        AllEmails = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognixed format " + format);
                }
            }
            else
            {
                System.Console.Out.Write("Выбран неверный тип. Напишите groups ИЛИ contacts");
            }
            writer.Close();
        }

        // Контакты
        static void writeContactsToCsvFile(List<ContactDate> contacts, StreamWriter writer)
        {
            foreach (ContactDate contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5}", 
                    contact.Firstname, contact.Lastname, 
                    contact.Middlename, 
                    contact.Address, contact.Company, contact.AllEmails));
            }
        }
        static void writeContactsToXmlFile(List<ContactDate> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactDate>)).Serialize(writer, contacts);
        }
        static void writeContactsToJsonFile(List<ContactDate> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        // Группы
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer) //функция, которая записывает в csv файл
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups); //создаём новый сериализатор
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
