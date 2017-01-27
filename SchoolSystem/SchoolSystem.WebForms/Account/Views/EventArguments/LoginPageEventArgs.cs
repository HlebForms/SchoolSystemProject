using Microsoft.Owin;
using SchoolSystem.WebForms.Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.Account.Views.EventArguments
{
    public class LoginPageEventArgs : EventArgs
    {

        public LoginPageEventArgs(LoginModel model, IOwinContext ctx)
        {
            this.Data = model;
            this.OwinCtx = ctx;
        }

        public LoginModel Data { get; set; }

        public IOwinContext OwinCtx { get; set; }

    }
}