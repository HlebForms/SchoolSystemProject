using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class CreatingSubjectEventArgs : EventArgs
    {
        public HttpPostedFile AvatarFile { get; internal set; }
        public string SubjectName { get; set; }
        public string SubjectPictureStoragePath { get; internal set; }
        public string SubjectPictureUrl { get; internal set; }
    }
}