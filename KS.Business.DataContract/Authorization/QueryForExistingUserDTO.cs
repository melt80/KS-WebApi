using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Business.DataContract.Authorization
{
    public class QueryForExistingUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
