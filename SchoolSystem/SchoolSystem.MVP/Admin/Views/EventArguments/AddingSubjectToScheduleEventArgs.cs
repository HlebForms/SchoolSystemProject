using System;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class AddingSubjectToScheduleEventArgs : EventArgs
    {
        public int SubjectId { get; set; }

        public int DaysOfWeekId { get; set; }

        public int ClassId { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }
    }
}