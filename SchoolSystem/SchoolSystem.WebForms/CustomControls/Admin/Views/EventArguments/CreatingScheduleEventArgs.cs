using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class CreatingScheduleEventArgs : EventArgs
    {
        public string ClassId { get; set; }

        public string DayOfWeekId { get; set; }
    }
}