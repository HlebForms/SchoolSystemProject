using System;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class ManagingScheduleEventArgs : EventArgs
    {
        public int ClassId { get; set; }

        public int DayOfWeekId { get; set; }
    }
}