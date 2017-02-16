using System;
using System.Collections.Generic;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class AssignSubjectsToTeacherEventArgs : EventArgs
    {
        public string TeacherId { get; set; }

        public IEnumerable<int> SubjectIds { get; set; }
    }
}