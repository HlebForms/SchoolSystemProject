using System;

namespace SchoolSystem.MVP.Teacher.Views.EventArguments
{
    public class BindStudentsEventArgs : EventArgs
    {
        public int ClassId { get; set; }
    }
}