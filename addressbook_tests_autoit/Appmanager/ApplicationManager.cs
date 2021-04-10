using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private GroupHelper groupHelper;
        private AutoItX3 aux;
        public static string WinTitle = "Free Address Book";
        public ApplicationManager() //конструктор
        {
            aux = new AutoItX3();
            aux.Run(@"C:\Users\Админ\source\repos\addressbook-web-tests\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WinTitle); //Ждём запуска
            aux.WinActivate(WinTitle); //Ждём активации
            aux.WinWaitActive(WinTitle); //Ждём запуска после активации

            groupHelper = new GroupHelper(this); 
        }

        public void Stop()
        {
            aux.WinWait(WinTitle);
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d510"); 
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
