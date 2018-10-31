using System;
using System.Collections.Generic;
using System.Text;

namespace KS.API.DataContract.Authorization
{
    public class ExistingUserQueryRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
