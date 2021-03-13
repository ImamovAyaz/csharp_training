using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupRemovealTests : AuthTestBase
    {

        [Test]
        public void GroupRemovealTest()
        {
            app.Groups.Remove(1);
        }
    }
}
