using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace GroupCreationTestsNew
{
    [TestFixture]
    public class GroupCreationTestNew : TestBase
    {
        [Test]
        public void GroupCreationTestsNew()
        {            
            GroupData group = new GroupData("aaa");
            group.Header = "fff";
            group.Footer = "ggg";


            app.Groups.Create(group);
            app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTestsNew()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }
}
