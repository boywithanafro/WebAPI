using myAlfred0._5APIwAuthenticationStartupFramework.Models;
using System.Threading.Tasks;

namespace myAlfredFrontEnd.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}