using System;
using System.Web;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class CreatingSubjectEventArgs : EventArgs
    {
        public HttpPostedFile AvatarFile { get; set; }

        public string SubjectName { get; set; }

        public string SubjectPictureStoragePath { get; set; }

        public string SubjectPictureUrl { get; set; }
    }
}