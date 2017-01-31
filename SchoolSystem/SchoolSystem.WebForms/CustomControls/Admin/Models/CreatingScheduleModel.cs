using SchoolSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin.Models
{
    public class CreatingScheduleModel
    {
        public IEnumerable<ClassOfStudents> AllClassOfStudents { get; set; }
    }
}