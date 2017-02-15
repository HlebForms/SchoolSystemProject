using System;
using WebFormsMvp;
using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.MVP.Home.Views;
using SchoolSystem.MVP.Home.Views.EventArguments;

namespace SchoolSystem.MVP.Home.Presenter
{
    public class SchedulePresenter : Presenter<IScheduleView>
    {
        private readonly IScheduleDataService service;

        public SchedulePresenter(IScheduleView view, IScheduleDataService service)
            : base(view)
        {
            this.service = service;
            this.View.EventBindStudentScheduleData += this.BindStudentScheduleData;
            this.View.EventBindTeacherScheduleData += this.BindTeacherScheduleData;
        }

        private void BindStudentScheduleData(object sender, ScheduleEventargs e)
        {
            var dayOfWeek = DateTime.Now.DayOfWeek;
            this.View.Model.StudentSchedule = service.GetStudentScheduleForTheDay(dayOfWeek, e.Username);
        }

        private void BindTeacherScheduleData(object sender, ScheduleEventargs e)
        {
            var dayOfWeek = DateTime.Now.DayOfWeek;
            this.View.Model.TeacherSchedule = service.GetTeacherScheduleForTheDay(dayOfWeek, e.Username);
        }
    }
}