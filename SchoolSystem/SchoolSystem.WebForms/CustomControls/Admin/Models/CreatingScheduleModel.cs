using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin.Models
{
    public class CreatingScheduleModel
    {

        public IEnumerable<ClassOfStudents> AllClassOfStudents { get; set; }

        public IEnumerable<DaysOfWeek> DaysOfWeek { get; set; }

        public IEnumerable<ManagingScheduleModel> CurrentSchedule { get; set; }

        public IEnumerable<Subject> SubjectForCurrentClass { get; internal set; }
    }
}