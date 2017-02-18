using System;
using System.Collections.Generic;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class CreatingClassOfStudentsEventArgs : EventArgs
    {
        public string ClassName { get; set; }

        public IEnumerable<string> SubjectIds { get; set; }
    }
}