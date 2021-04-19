using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisBT_test
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<Mantis.ProjectData> GetAllProject(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projects = new Mantis.ProjectData();
            Mantis.ProjectData[] allprojects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            List<Mantis.ProjectData> list = new List<Mantis.ProjectData>();
            foreach (var project in allprojects)
            {
                list.Add(project);
            }
            return list;
        }

        public void Create(ProjectData projectData, AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projects = new Mantis.ProjectData();
            projects.name = projectData.Name;
            client.mc_project_add(account.Username, account.Password, projects);
        }
    }
}
