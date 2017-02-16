using System;

using SchoolSystem.MVP.Account.Models;

using Microsoft.Owin;

namespace SchoolSystem.MVP.Account.Views.EventArguments
{
    public class LoginPageEventtArgs : EventArgs
    {
        public LoginPageEventtArgs()
        {
        }

        public LoginPageEventtArgs(LoginModel model, IOwinContext ctx)
        {
            this.Data = model;
            this.OwinCtx = ctx;
        }

        public LoginModel Data { get; set; }

        public IOwinContext OwinCtx { get; set; }
    }
}