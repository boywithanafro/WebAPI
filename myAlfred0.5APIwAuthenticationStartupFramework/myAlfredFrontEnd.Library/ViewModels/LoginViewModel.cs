using Caliburn.Micro;
using myAlfredFrontEnd.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAlfredFrontEnd.Library.ViewModels
{
    public class LoginViewModel : Screen//(using refernce caliburn)
    {
        private string _userName; // Underscore is because it is a private backing field, sole pupose to supply and hold value for this property
        private string _password;
        private IAPIHelper _apiHelper;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public bool CanLogIn(string userName, string password)
        {
            bool output = false;
            if (userName.Length > 0 && password.Length > 0)
            {
                output = true;
            }

            return output;
        }

        public async Task LogIn() //(string username, string password)
        {
            var result = await _apiHelper.Authenticate(UserName, Password); // Result is an AuthenticatedUser model
            Console.WriteLine();
        }

    }
}
