using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class AuthTestBase : TestBase// Будет использоваться для тестов для которых нужна авторизация на стенде
    {
        [SetUp]
        public void SetupLogin()
        {       
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
