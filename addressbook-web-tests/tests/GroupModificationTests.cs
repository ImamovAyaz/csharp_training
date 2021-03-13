using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase // Тесты наследуются от базового тестового класса
    {
        [Test]
        public void GroupModificationTest()  // тестовый метод
        {
            GroupData newData = new GroupData("aaa123");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
        }

    }
}
