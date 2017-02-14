using System;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments
{
    public class BindClassesEventArgs : EventArgs
    {
        public int SubjectId { get; internal set; }
    }
}