using System;
using System.Web;

namespace SchoolSystem.MVP.Account.Views.EventArguments
{
    public class AvatarUploadEventArgs : EventArgs
    {
        public string UserAvatarUrl { get; set; }

        public HttpPostedFile PostedFile { get; set; }

        public string LoggedUserUserName { get; set; }

        public string AvatarStorateLocation { get; set; }
    }
}