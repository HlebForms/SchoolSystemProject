using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using System.Collections.Generic;

namespace SchoolSystem.MVP.Admin.Models
{
    public class ManagingScheduleControlModel
    {
        public IEnumerable<ClassOfStudents> AllClassOfStudents { get; set; }

        public IEnumerable<DaysOfWeek> DaysOfWeek { get; set; }

        public IEnumerable<ManagingScheduleModel> CurrentSchedule { get; set; }

        public IEnumerable<Subject> SubjectForCurrentClass { get; internal set; }

        public bool IsInsertingSuccessFull { get; set; }
    }
}