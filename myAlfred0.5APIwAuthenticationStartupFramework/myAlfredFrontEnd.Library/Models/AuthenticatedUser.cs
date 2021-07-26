using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myAlfred0._5APIwAuthenticationStartupFramework.Models
{
    public class AuthenticatedUser
    {
        // The properties that we care about for authenticatedUser
        public string Access_Token { get; set; }
        public string UserName { get; set; }
    }
}