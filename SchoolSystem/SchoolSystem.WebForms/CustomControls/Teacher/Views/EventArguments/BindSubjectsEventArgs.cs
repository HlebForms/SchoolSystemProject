using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments
{
    public class BindSubjectsEventArgs : EventArgs
    {
        public bool IsAdmin { get; set; }

        public string TecherName { get; set; }
    }
}