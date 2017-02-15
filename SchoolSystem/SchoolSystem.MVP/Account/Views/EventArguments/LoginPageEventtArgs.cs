using System;

using Microsoft.Owin;
using SchoolSystem.MVP.Account.Models;

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