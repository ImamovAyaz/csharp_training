using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown] // Будет выполнятсья после каждого тестового метода
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactDate> fromUi = app.Contacts.GetContactsList();
                List<ContactDate> fromDb = ContactDate.GetAll();
                fromUi.Sort();
                fromDb.Sort();
                Assert.AreEqual(fromUi, fromDb);
            }

        }
    }
}
