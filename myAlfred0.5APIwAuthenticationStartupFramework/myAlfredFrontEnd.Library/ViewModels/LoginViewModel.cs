using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAlfredFrontEnd.Library.ViewModels
{
    public class LoginViewModel : Screen//(using refernce caliburn)
    {
        private string _username; // Underscore is because it is a private backing field, sole pupose to supply and hold value for this property
        private string _password;

        public string UserName
        {
            get { return _username; }
            set 
            { 
                _username = value;
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

        public bool CanLogIn(string username, string password)
        {
            bool output = false;
            if (username.Length > 0 && password.Length > 0)
            {
                output = true;
            }

            return output;
        }

        public void LogIn(string username, string password)
        {
            Console.WriteLine();
        }

    }
}
