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

        public IEnumerable<DaysOfWeek> DaysOfWeek { get; set; }

        public IList<Test> CurrentSchedule { get; set; } = new List<Test>                 {
                    new Test() {Id=1,ClassName="12a",StartHour = 11, EndHour = 12, SubjName = "matem", DayOfWeek = "Monday" },
                    new Test() {Id=2,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "bg", DayOfWeek = "Tuesday" },
                    new Test() {Id=3,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "lit", DayOfWeek = "Thursday" },
                    new Test() {Id=4,ClassName="12a",StartHour = 11, EndHour = 12, SubjName = "fvs", DayOfWeek = "Thursday" },
                    new Test() {Id=5,ClassName="12a",StartHour = 11, EndHour = 12, SubjName = "neshto", DayOfWeek = "Thursday" },
                    new Test() {Id=6,ClassName="12a",StartHour = 11, EndHour = 12, SubjName = "drugo", DayOfWeek = "Thursday" },
                    new Test() {Id=7,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "ala", DayOfWeek = "Thursday" },
                    new Test() {Id=8,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "bala", DayOfWeek = "Thursday" },
                    new Test() {Id=9,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "matem", DayOfWeek = "Monday" },
                    new Test() {Id=10,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "makro", DayOfWeek = "Monday" },
                    new Test() {Id=11,ClassName="12a",StartHour = 11, EndHour = 12, SubjName = "matem", DayOfWeek = "Monday" },
                    new Test() {Id=12,ClassName="12a",StartHour = 11, EndHour = 12, SubjName = "finansi", DayOfWeek = "Monday" },
                    new Test() {Id=13,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "matem", DayOfWeek = "Monday" },
                    new Test() {Id=14,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "ssss", DayOfWeek = "Monday" },
                    new Test() {Id=15,ClassName="11a",StartHour = 11, EndHour = 12, SubjName = "petak11", DayOfWeek = "Friday" },
                };
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