using System;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments
{
    public class BindStudentsEventArgs : EventArgs
    {
        public int ClassId { get; set; }
    }
}