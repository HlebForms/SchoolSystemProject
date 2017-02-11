using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments
{
    public class BindClassesEventArgs : EventArgs
    {
        public int SubjectId { get; internal set; }
    }
}