using System.Web;
using System.Web.Mvc;

namespace myAlfred0._5APIwAuthenticationStartupFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
