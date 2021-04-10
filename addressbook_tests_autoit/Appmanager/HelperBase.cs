using System.Text;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WinTitle;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            WinTitle = ApplicationManager.WinTitle;
            this.aux = manager.Aux;
        }
    }
}