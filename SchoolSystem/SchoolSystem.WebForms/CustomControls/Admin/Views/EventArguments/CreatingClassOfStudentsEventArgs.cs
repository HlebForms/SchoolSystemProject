using SchoolSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class CreatingClassEventArgs : EventArgs
    {
        public string ClassName { get; set; }

        public IEnumerable<Subject> Subjects{ get; set; }
    }
}