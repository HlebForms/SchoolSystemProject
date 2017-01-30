using SchoolSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class CreatingClassOfStudentsEventArgs : EventArgs
    {
        public string ClassName { get; set; }

        public IEnumerable<Subject> Subjects{ get; set; }
    }
}