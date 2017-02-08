using System;

using SchoolSystem.WebForms.Account.Models;

using Microsoft.Owin;
using SchoolSystem.WebForms.CustomControls.Account.Models;

namespace SchoolSystem.WebForms.CustomControls.Account.Views.EventArguments
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