using Microsoft.Owin;
using SchoolSystem.WebForms.Account.Models;
using System;

namespace SchoolSystem.WebForms.Account.Views.EventArguments
{
    public class AuhenticationEventArgs : EventArgs
    {
        public AuhenticationEventArgs()
        {

        }

        public AuhenticationEventArgs(LoginModel model, IOwinContext ctx)
        {
            this.Data = model;
            this.OwinCtx = ctx;
        }

        public LoginModel Data { get; set; }

        public IOwinContext OwinCtx { get; set; }

    }
}