using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class ManagingScheduleEventArgs : EventArgs
    {
        public string ClassId { get; set; }

        public string DayOfWeekId { get; set; }
    }
}