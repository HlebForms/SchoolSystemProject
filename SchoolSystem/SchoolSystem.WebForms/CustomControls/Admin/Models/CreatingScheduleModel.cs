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
    }

    public class Test
    {
        public int Id { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }

        public string SubjName { get; set; }

        public string DayOfWeek { get; set; }

        public string ClassName { get; set; }
    }
}