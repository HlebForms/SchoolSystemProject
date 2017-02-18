using System;

namespace SchoolSystem.MVP.Student.Views.EventArguments
{
    public class GetStudentMarksEventArgs : EventArgs
    {
        public string StudentName { get; set; }
    }
}