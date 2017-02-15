using System;

namespace SchoolSystem.Data.Models.CustomModels
{
    public class ScheduleModel
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public string TeacherName { get; set; }

        public string ClassName { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }
    }
}