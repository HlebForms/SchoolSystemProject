using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Data.Models;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IScheduleDataService
    {
        IEnumerable<StudentSchedule> GetTodaysSchedule(DayOfWeek dayOfWeek, string username);

        IEnumerable<DaysOfWeek> GetAllDaysOfWeek();
    }
}
