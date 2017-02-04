using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class RemovingSubjectFromScheduleEventArgs : EventArgs
    {
        public int SubjectId { get; set; }
        public int DaysOfWeekId { get; set; }
        public int ClassId { get; set; }
    }
}