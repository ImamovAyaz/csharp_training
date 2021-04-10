using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GroupWinTitle = "Group editor";
        public static string GroupDeleteTitle = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            // получаем количество групп
            string count = aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", ""); // ControlTreeView - команда AutoIt которая работает с классами SysTreeView
            for (int i = 0; i < int.Parse(count); i++)
            {
                //получаем список наименовании существующих групп
                string item = aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        public void Remove(int index)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
               "Select", "#0|#" + index, "");
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d51"); //Нажимаем Delete
            aux.WinWait(GroupDeleteTitle);
            aux.ControlTreeView(GroupDeleteTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
               "Select", "#0|#" + index, "");         
            aux.ControlClick(GroupDeleteTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GroupWinTitle);
            CloseGroupsDialogue();
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53"); // Нажимаем кнопку New в окне создания группы
            aux.Send(newGroup.Name); // Вводим наименование группы
            aux.Send("{ENTER}"); // Эмулируем нажатие клавиши Enter
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d512"); //Нажимаем по кнопке "Папка"
            aux.WinWait(GroupWinTitle); // Ждём открытия окна
        }
    }
}