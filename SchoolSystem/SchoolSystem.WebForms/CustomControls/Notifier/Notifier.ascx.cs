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

        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        public void NotifySuccess(string text)
        {
            this.NotificationPane.Attributes["class"] = "alert alert-dismissible alert-success";
            this.NotificationPane.Visible = true;
            this.NotificationMessage.Text = text;
        }

        public void NotifyError(string text)
        {
            this.NotificationPane.Attributes["class"] = "alert alert-dismissible alert-error";
            this.NotificationPane.Visible = true;
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

