using SchoolSystem.WebForms.CustomControls.Home.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Home.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.WebForms.CustomControls.Home.Presenter
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