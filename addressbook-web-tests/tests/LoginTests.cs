using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework; // пространство имён NUnit.Framework
using System.Threading.Tasks;

namespace AddressBookWebTests
{
    [TestFixture] //помечаем атрибутом TestFixture потому что это тестовый класс
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // готовим тестовую ситуацию
            app.Auth.Logout();
            // действие залогиниться
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            // проверка соответствия залогиненному пользовалю
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInValidCredentials() //проверка на невалидные данные
        {
            // готовим тестовую ситуацию
            app.Auth.Logout();
            // действие залогиниться
            AccountData account = new AccountData("admin", "1234");
            app.Auth.Login(account);
            // проверка соответствия залогиненному пользовалю
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
