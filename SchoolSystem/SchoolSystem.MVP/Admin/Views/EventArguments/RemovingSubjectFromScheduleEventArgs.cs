using System;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class RemovingSubjectFromScheduleEventArgs : EventArgs
    {
        public int SubjectId { get; set; }

        public int DaysOfWeekId { get; set; }

        public int ClassId { get; set; }
    }
}