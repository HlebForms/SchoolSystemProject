using System;
using System.Collections.Generic;

using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Data.Models;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IScheduleDataService
    {
        IEnumerable<StudentSchedule> GetStudentScheduleForTheDay(DayOfWeek dayOfWeek, string username);

        IEnumerable<DaysOfWeek> GetAllDaysOfWeek();

        IEnumerable<ManagingScheduleModel> GetTodaysSchedule(int dayOfWeekId, int classId);

        bool AddSubjectToSchedule(int classId, int subjectId, int dayOfWeekId, DateTime startHour, DateTime endHour);

        void RemoveSubjectFromSchedule(int classId, int daysOfWeekId, int subjectId);
    }
}
