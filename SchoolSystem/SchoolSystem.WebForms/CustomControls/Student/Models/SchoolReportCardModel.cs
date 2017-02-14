using SchoolSystem.Data.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Student.Models
{
    public class SchoolReportCardModel
    {
        public IEnumerable<StudentMarks> StudentMarks { get; set; }
    }
}