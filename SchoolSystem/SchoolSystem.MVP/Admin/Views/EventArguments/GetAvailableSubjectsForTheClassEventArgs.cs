using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class GetAvailableSubjectsForTheClassEventArgs :EventArgs
    {
        public int ClassOfStudentsId { get; set; }
    }
}