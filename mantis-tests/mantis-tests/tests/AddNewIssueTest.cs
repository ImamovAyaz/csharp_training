using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTest : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "qwerty123"
            };
            ProjectData project = new ProjectData()
            {
                Id = "1"
            };
            IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"
            };
            app.API.CreateNewIssue(account, project, issue);

        }

    }
}
