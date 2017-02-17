using System;

using SchoolSystem.MVP.Home.Views;
using SchoolSystem.MVP.Home.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

using Bytes2you.Validation;
using WebFormsMvp;

namespace SchoolSystem.MVP.Home.Presenter
{
    public class SchedulePresenter : Presenter<IScheduleView>
    {
        private readonly IScheduleDataService scheduleDataService;

        public SchedulePresenter(IScheduleView view, IScheduleDataService scheduleDataService)
            : base(view)
        {
            Guard.WhenArgument(scheduleDataService, "scheduleDataService").IsNull().Throw();

            this.scheduleDataService = scheduleDataService;

            this.View.EventBindStudentScheduleData += this.BindStudentScheduleData;
            this.View.EventBindTeacherScheduleData += this.BindTeacherScheduleData;
        }

        private void BindStudentScheduleData(object sender, ScheduleEventargs e)
        {
            var dayOfWeek = DateTime.Now.DayOfWeek;
            this.View.Model.StudentSchedule = scheduleDataService.GetStudentScheduleForTheDay(dayOfWeek, e.Username);
        }

        private void BindTeacherScheduleData(object sender, ScheduleEventargs e)
        {
            var dayOfWeek = DateTime.Now.DayOfWeek;
            this.View.Model.TeacherSchedule = scheduleDataService.GetTeacherScheduleForTheDay(dayOfWeek, e.Username);
        }
    }
}