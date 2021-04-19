using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisBT_test
{
    [TestFixture]
    public class ProjectRemoveTests : AuthTestBase
    {
        [Test]
        public void TestRemoveProject()
        {
            app.Project.ProjectElementVerification();
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "qwerty123"
            };
            ProjectData project = new ProjectData()
            {
                Name = "testProjectFromAPI"
            };
            // List<ProjectData> oldProjects = app.Project.GetAllFromUI();
            List<Mantis.ProjectData> oldProjects = app.API.GetAllProject(account);
            int toBeRemoved = 0;
            if (oldProjects.Count == 0)
            {
                app.API.Create(project, account);
            }
            app.Project.Remove(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = app.Project.GetAllFromUI();

            oldProjects.RemoveAt(toBeRemoved);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}