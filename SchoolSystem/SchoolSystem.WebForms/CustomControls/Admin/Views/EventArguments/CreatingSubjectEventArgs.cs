﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class CreatingSubjectEventArgs : EventArgs
    {
        public string SubjectName { get; set; }
    }
}