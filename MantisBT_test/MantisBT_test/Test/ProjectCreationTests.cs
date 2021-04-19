using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisBT_test
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        public static IEnumerable<ProjectData> RandomDataProvider()
        {
            List<ProjectData> project = new List<ProjectData>();
            for (int i = 0; i < 3; i++)
            {
                project.Add(new ProjectData()
                {
                    Name = GenerateRandomString(30),
                });
            }
            return project;
        }

        [Test, TestCaseSource("RandomDataProvider")]
        public void TestCreateProject(Mantis.ProjectData project)
        {
            // List<ProjectData> oldProjects = app.Project.GetAllFromUI();
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "qwerty123"
            };
            List<Mantis.ProjectData> oldProjects = app.API.GetAllProject(account);

            app.Project.Creation(project);

            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = app.Project.GetAllFromUI();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}