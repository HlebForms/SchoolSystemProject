using System;

namespace SchoolSystem.MVP.Teacher.Views.EventArguments
{
    public class BindSchoolReportCardEventArgs : EventArgs
    {
        public int SubjectId { get; set; }

        public int ClassOfStudentsId { get; set; }
    }
}