using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp] //чтобы тест выполнился один раз для всех тестов в этом классе
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("C:/Users/Админ/source/repos/mantis-tests/mantis-tests/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            };
        }
        [Test]
        public void TestAccountRegistretion()
        {

            AccountData account = new AccountData()
            {
                Name = "testuser5",
                Password = "password",
                Email = "testuser5@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();

            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount); //Удаляем существующий аккаунт
            }
            app.Registration.Register(account);
        }
        [TestFixtureTearDown]
        public void restoreConfig()//Восстановление конфигурационного файла, который был скрыт в начале
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
