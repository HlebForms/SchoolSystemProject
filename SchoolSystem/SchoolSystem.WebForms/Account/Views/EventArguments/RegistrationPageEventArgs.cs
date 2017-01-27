using Microsoft.Owin;
using SchoolSystem.WebForms.Account.Models;
using System;

namespace SchoolSystem.WebForms.Account.Views.EventArguments
{
    public class RegistrationPageEventArgs : EventArgs
    {
        public RegistrationPageEventArgs(RegistrationModel model, IOwinContext ctx)
        {
            this.Model = model;
            this.OwinCtx = ctx;
        }

        public RegistrationModel Model { get; set; }

        public IOwinContext OwinCtx { get; set; }
    }
}