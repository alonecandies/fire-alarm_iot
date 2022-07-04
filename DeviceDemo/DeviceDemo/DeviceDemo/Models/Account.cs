using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceDemo.Models
{
    public class Account : BsonData.Document
    {
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public class AccountBinding : Account
    {
        public string UserName { get; set; }

    }
    public class UserInfo : BsonData.Document
    {
        public string Name { get; set; }
        public Account Account { get; set; }
    }
}