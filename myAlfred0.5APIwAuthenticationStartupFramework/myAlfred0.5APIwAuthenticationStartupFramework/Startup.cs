using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(myAlfred0._5APIwAuthenticationStartupFramework.Startup))]

namespace myAlfred0._5APIwAuthenticationStartupFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
