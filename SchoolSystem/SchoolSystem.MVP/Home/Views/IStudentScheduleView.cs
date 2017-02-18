using System;
using SchoolSystem.MVP.Home.Models;
using SchoolSystem.MVP.Home.Views.EventArguments;
using WebFormsMvp;

namespace SchoolSystem.MVP.Home.Views
{
    public interface IScheduleView : IView<ScheduleControlModel>
    {
        event EventHandler<ScheduleEventargs> EventBindStudentScheduleData;

        event EventHandler<ScheduleEventargs> EventBindTeacherScheduleData;
    }
}
