using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace GroupCreationTestsNew
{
    [TestFixture]
    public class GroupModificationTests : TestBase // Тесты наследуются от базового тестового класса
    {
        [Test]
        public void GroupModificationTest()  // тестовый метод
        {
            GroupData newData = new GroupData("aaa123");
            newData.Header = "fff123";
            newData.Footer = "ggg123";

            app.Groups.Modify(1, newData);
        }

    }
}
