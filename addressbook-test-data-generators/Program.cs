using System;
using AddressBookWebTests;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel; //Присваем новый префикс для более понятного и короткого доступа к классам эксель

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeData = args[0]; //выбираем, contact или group
            int count = Convert.ToInt32(args[1]); //аргумент 1 -Количество тестjвых данных, которые хотим сгенерировать
                                                  //Для записи в текстовый файл используется класс StreamWriter.
            string filename = args[2];
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
                if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(args[2]); // аргумент 2 - Название файла, в который будем писать сгенерированные данные
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
                    });
                }
                if (format == "excel")
                {
                    writeContactsToExcelFile(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(args[2]); // аргумент 2 - Название файла, в который будем писать сгенерированные данные
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
                    writer.Close();
                }
            }
            else
            {
                System.Console.Out.Write("Выбран неверный тип. Напишите groups ИЛИ contacts");
            }
        }

        // Контакты
        static void writeContactsToCsvFile(List<ContactDate> contacts, StreamWriter writer)
        {
            foreach (ContactDate contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4}",
                    contact.Firstname, contact.Lastname,
                    contact.Middlename,
                    contact.Address, contact.Company));
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
        static void writeContactsToExcelFile(List<ContactDate> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet();
            int row = 1;
            foreach (ContactDate contact in contacts) //цикл для записи данных контактов в эксель файл
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Middlename;
                sheet.Cells[row, 3] = contact.Lastname;
                sheet.Cells[row, 4] = contact.Address;
                sheet.Cells[row, 5] = contact.Company;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath); //удаляем файл, чтобы при дальнейшем сохранении ОС не запрашивала другую деректорию
            wb.SaveAs(fullPath); //сохраняем эксель файл в директории, в которой находится проект
            wb.Close(); //закрываем эксель приложение
            app.Visible = false;
            app.Quit(); //очищаем ранее открытое приложение из памяти устройства
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
        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            //Запуск Эксель через COM интерфейс. Обратить внимание на префикс в using
            Excel.Application app = new Excel.Application();
            app.Visible = true; //Чтобы видеть что происходит это в окне эксель для визуального наблюдения
            Excel.Workbook wb = app.Workbooks.Add(); //Добавляем новый документ
            Excel.Worksheet sheet = wb.ActiveSheet; //Создаём страницу в эксель
            int row = 1;
            foreach (GroupData group in groups) //цикл для записи данных группы в эксель файл
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath); //удаляем файл, чтобы при дальнейшем сохранении ОС не запрашивала другую деректорию
            wb.SaveAs(fullPath); //сохраняем эксель файл в директории, в которой находится проект
            wb.Close(); //закрываем эксель приложение
            app.Visible = false;
            app.Quit(); //очищаем ранее открытое приложение из памяти устройства
        }
    }
}
