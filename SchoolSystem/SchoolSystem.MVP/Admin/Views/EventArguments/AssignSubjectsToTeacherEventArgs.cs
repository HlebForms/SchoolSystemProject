using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class AssignSubjectsToTeacherEventArgs : EventArgs
    {
        public string TeacherId { get; set; }

        public IEnumerable<int> SubjectIds { get; set; }
    }
}