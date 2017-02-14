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
    public class StudentSchedulePresenter : Presenter<IStudentScheduleView>
    {
        private readonly IScheduleDataService service;

        public StudentSchedulePresenter(IStudentScheduleView view, IScheduleDataService service)
            : base(view)
        {
            this.service = service;
            this.View.EventBindScheduleData += this.BindScheduleData;
        }

        private void BindScheduleData(object sender, StudentScheduleEventargs e)
        {
            var dayOfWeek = DateTime.Now.DayOfWeek;
            this.View.Model.StudentSchedule = service.GetStudentScheduleForTheDay(dayOfWeek, e.Username);

        }
    }
}