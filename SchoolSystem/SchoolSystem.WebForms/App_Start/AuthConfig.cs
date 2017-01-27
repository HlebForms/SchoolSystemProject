using Owin;
using SchoolSystem.Web.Services.Auth.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.App_Start
{
    public class AuthConfig
    {
        private readonly IAuthService authService;

        public AuthConfig(IAuthService authService)
        {
            if (authService == null)
            {
                throw new ArgumentNullException("authService");
            }

            this.authService = authService;
        }

        public AuthConfig(IAppBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            this.authService.AuthConfig(app);
        }
    }
}