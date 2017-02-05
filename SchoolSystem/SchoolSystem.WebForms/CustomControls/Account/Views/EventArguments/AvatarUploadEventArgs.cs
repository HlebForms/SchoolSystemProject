using System;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Account.Views.EventArguments
{
    public class AvatarUploadEventArgs : EventArgs
    {
        public HttpPostedFile PostedFile { get; set; }

        public string LoggedUserUserName { get; set; }

        public string AvatarStorateLocation { get; set; }

        public string UserAvatarUrl { get; set; }
    }
}