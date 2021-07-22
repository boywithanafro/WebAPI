using Microsoft.AspNet.Identity;
using myAlfredFramework.Library.DataAccess;
using myAlfredFramework.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace myAlfred0._5APIwAuthenticationStartupFramework.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById() // Not including id as param to prevent users from choosing who they want to login as, instead we retrieve the logged in user
        { // New connection to Library and call UserData
            string userId = RequestContext.Principal.Identity.GetUserId(); // Retrieve logged in user

            UserData data = new UserData();

            return data.GetUserById(userId).First(); // Returns UserModel which is user data
        }
    }
}
