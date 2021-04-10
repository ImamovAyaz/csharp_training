using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [TestFixtureSetUp] // атрибут, который задаёт правило выполнения перед всеми остальным тестами
        public void initApplication()
        {
            app = new ApplicationManager();

        }

        //[TestFixtureTearDown]
        [TestFixtureTearDown] //Выполняется в конце теста
        public void stopApplication()
        {
            app.Stop();
        }
    }
}
