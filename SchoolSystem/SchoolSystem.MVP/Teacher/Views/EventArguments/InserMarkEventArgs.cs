using System;

namespace SchoolSystem.MVP.Teacher.Views.EventArguments
{
    public class InserMarkEventArgs : EventArgs
    {
        public int SubjectId { get; set; }

        public string StudentId { get; set; }

        public int MarkId { get; set; }
    }
}