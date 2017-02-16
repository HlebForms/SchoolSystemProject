using System;

namespace SchoolSystem.Data.Models.CustomModels
{
    public class ManagingScheduleModel
    {
        public int Id { get; set; }

        public DaysOfWeek DaysOfWeek { get; set; }

        public DateTime StartHour { get; set; }

        public Subject Subject { get; set; }

        public DateTime EndHour { get; set; }
    }
}
