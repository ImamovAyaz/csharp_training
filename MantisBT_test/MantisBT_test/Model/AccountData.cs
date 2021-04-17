using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBT_test
{
    public class AccountData
    {
        //private string username;
        //private string password;
        //public AccountData(string username, string password)
        //{
        //    this.username = username;
        //    this.password = password;
        //}
        public string Username { get; set; }
        public string Password { get; set; }
        public string Id { get; internal set; }
    }
}
