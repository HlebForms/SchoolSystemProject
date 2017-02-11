using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments
{
    public class BindMarksEventArgs : EventArgs
    {
        public int SubjectId { get; set; }
        public int ClassOfStudentsId { get; set; }
    }
}