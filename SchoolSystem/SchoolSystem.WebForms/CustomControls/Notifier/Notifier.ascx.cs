using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolSystem.WebForms.CustomControls.Notifier
{
    public partial class Notifier : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.NotificationPane.Visible = false;
        }

        public void NotifySuccess(string text)
        {
            this.NotificationPane.Visible = true;
            this.NotificationPane.CssClass = "alert alert-dismissible alert-success";
            this.NotificationMessage.Text = text;
        }

        public void NotifyError(string text)
        {
            this.NotificationPane.Visible = true;
            this.NotificationPane.CssClass = "alert alert-dismissible alert-error";
            this.NotificationMessage.Text = text;
        }
    }

    public enum NotificationType
    {
        Error,
        Success,
        Warning
    }
}

