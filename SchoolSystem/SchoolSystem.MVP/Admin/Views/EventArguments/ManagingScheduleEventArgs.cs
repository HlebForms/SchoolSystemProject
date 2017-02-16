using System;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class ManagingScheduleEventArgs : EventArgs
    {
        public string ClassId { get; set; }

        public string DayOfWeekId { get; set; }
    }
}