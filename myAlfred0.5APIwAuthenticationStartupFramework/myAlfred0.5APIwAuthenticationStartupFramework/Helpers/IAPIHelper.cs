using myAlfred0._5APIwAuthenticationStartupFramework.Models;
using System.Threading.Tasks;

namespace myAlfred0._5APIwAuthenticationStartupFramework.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}