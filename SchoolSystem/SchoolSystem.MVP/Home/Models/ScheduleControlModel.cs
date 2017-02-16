using System.Collections.Generic;

using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Home.Models
{
    public class ScheduleControlModel
    {
        public IEnumerable<ScheduleModel> StudentSchedule { get; set; }

        public IEnumerable<ScheduleModel> TeacherSchedule { get; set; }
    }
}