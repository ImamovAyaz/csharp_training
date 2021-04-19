using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AccountData
    {
        public string Id { get; internal set; }
        public string Name { get; set; } //свойство (property) AccountData
        public string Password { get; set; } //свойство (property) AccountData
        public string Email { get; set; }
    }
}
