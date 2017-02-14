using System;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments
{
    public class BindReortCardEventArgs : EventArgs
    {
        public int SubjectId { get; set; }

        public int ClassOfStudentsId { get; set; }
    }
}